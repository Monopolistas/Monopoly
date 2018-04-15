using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameGui : MonoBehaviour
{

    public GameController gameController;

    public GameNetwork gameNetwork;

    public Button join;
    public Button startGame;
    public Button quit;
    public Button throwDice;

    public Text connectionText;
    public Text playerNameText;
    public Text otherPlayersNameText;

    public GameObject black;
    public GameObject blue;
    public GameObject green;
    public GameObject red;
    public GameObject white;
    public GameObject yellow;

    public enum StateEnum
    {
        ON_START = 1,
        ON_JOIN_PRESSED = 2,
        ON_CONNECTING = 3,
        ON_CONNECTED = 4,
        ON_START_PRESSED = 5,
        ON_PLAYERS_CREATION = 6,
        ON_GAME = 7,
        ON_GAME_OVER = 8
    }

    GameStateMachine gameStateMachine;
    StateEnum currentState;

    // Use this for initialization
    void Start()
    {
        gameStateMachine = gameController.gameStateMachine;

        currentState = StateEnum.ON_START;
    }

    private void Update()
    {
        switch (currentState)
        {
            case StateEnum.ON_START:
                join.interactable = true;
                startGame.interactable = false;
                throwDice.interactable = false;
                break;
            case StateEnum.ON_JOIN_PRESSED:
                join.interactable = false;
                ChangeState();
                break;
            case StateEnum.ON_CONNECTING:
                connectionText.text = "Connecting...";
                break;
            case StateEnum.ON_CONNECTED:
                connectionText.text = "Connected!";
                playerNameText.text = gameStateMachine.Owner == null ? "" : gameStateMachine.Owner.Name + ":" + PhotonNetwork.player;
                if (gameStateMachine.Database.PlayerDictionary.Count > 0)
                {
                    string names = "";
                    foreach (Player item in gameStateMachine.Database.PlayerDictionary.Values)
                    {
                        names += item.Name + "\n";
                    }
                    otherPlayersNameText.text = names;
                }
                if (PhotonNetwork.isMasterClient)
                {
                    startGame.interactable = true;
                }
                else
                {
                    if (gameStateMachine.IsClientPrepared && gameStateMachine.IsGameStarted)
                    {
                        ChangeState(StateEnum.ON_PLAYERS_CREATION);
                    }
                }
                break;
            case StateEnum.ON_START_PRESSED:
                if (PhotonNetwork.isMasterClient)
                {
                    startGame.interactable = false;
                }
                ChangeState();
                break;
            case StateEnum.ON_PLAYERS_CREATION:
                if (gameStateMachine.IsGameStarted &&
                    gameStateMachine.Board != null &&
                    gameStateMachine.Board.PlayerList != null &&
                    gameStateMachine.Board.PlayerList.Count > 0)
                {
                    InstantiatePlayers();
                    ChangeState();
                }
                break;
            case StateEnum.ON_GAME:
                if (gameStateMachine.IsGameStarted &&
                    gameStateMachine.Board != null &&
                    gameStateMachine.Board.PlayerList != null &&
                    gameStateMachine.Board.PlayerList.Count > 0)
                {
                    if (gameStateMachine.Board.PlayerList.Count > 0)
                    {
                        string names = "";
                        foreach (Player item in gameStateMachine.Board.PlayerList)
                        {
                            // Write players' names
                            if (item.Id.Equals(gameStateMachine.PlayerOnTurn.Id))
                            {
                                names += "=> " + item.Name + " <=\n";
                            }
                            else
                            {
                                names += item.Name + "\n";
                            }

                            // Update players' position
                            UpdatePlayersPositions(item);
                        }
                        otherPlayersNameText.text = names;
                    }
                    if (gameStateMachine.Owner.Id.Equals(gameStateMachine.PlayerOnTurn.Id))
                    {
                        throwDice.interactable = true;
                    }
                }
                break;
            case StateEnum.ON_GAME_OVER:
                break;
        }
    }

    private void UpdatePlayersPositions(Player item)
    {
        int index = gameStateMachine.Board.FindIndexWherePlayerIs(item);

        float x = Constants.START_X;
        float y = Constants.START_Y;
        if (index >= 0 && index <= 10)
        {
            float offsetX = (index * Constants.TILE_BOARD_SIZE);
            float offsetY = 0;
            x += offsetX;
            y += offsetY;
        }
        if (index >= 11 && index <= 20)
        {
            index -= 10;
            float offsetX = 10 * Constants.TILE_BOARD_SIZE;
            float offsetY = index * Constants.TILE_BOARD_SIZE;
            x += offsetX;
            y += offsetY;
        }
        if (index >= 21 && index <= 30)
        {
            index -= 20;
            index = 10 - index;
            float offsetX = index * Constants.TILE_BOARD_SIZE;
            float offsetY = 10 * Constants.TILE_BOARD_SIZE;
            x += offsetX;
            y += offsetY;
        }
        if (index >= 31)
        {
            index -= 30;
            index = 10 - index;
            float offsetX = 0;
            float offsetY = index * Constants.TILE_BOARD_SIZE;
            x += offsetX;
            y += offsetY;
        }

        if (item.PlayerColor.Name.Equals(PlayerColor.BLACK.Name))
        {
            black.transform.position = new Vector3(x, y, 0);
        }
        if (item.PlayerColor.Name.Equals(PlayerColor.BLUE.Name))
        {
            blue.transform.position = new Vector3(x, y, 0);
        }
        if (item.PlayerColor.Name.Equals(PlayerColor.GREEN.Name))
        {
            green.transform.position = new Vector3(x, y, 0);
        }
        if (item.PlayerColor.Name.Equals(PlayerColor.RED.Name))
        {
            red.transform.position = new Vector3(x, y, 0);
        }
        if (item.PlayerColor.Name.Equals(PlayerColor.WHITE.Name))
        {
            white.transform.position = new Vector3(x, y, 0);
        }
        if (item.PlayerColor.Name.Equals(PlayerColor.YELLOW.Name))
        {
            yellow.transform.position = new Vector3(x, y, 0);
        }
    }

    public void Join()
    {
        ChangeState();
        gameNetwork.JoinGame();
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void StartGame()
    {
        gameStateMachine.ChangeState(gameStateMachine.StateOnPreparation);
        ChangeState();
    }

    public void ThrowDice()
    {
        gameStateMachine.ThrowDice(gameStateMachine.Owner.Id);
    }

    public void EndGame()
    {
        ChangeState();
    }

    public void InstantiatePlayers()
    {
        foreach (Player p in gameStateMachine.Board.PlayerList)
        {
            float x = Constants.START_X;
            float y = Constants.START_Y;
            black.transform.position = new Vector3(x, y, 0);
            blue.transform.position = new Vector3(x, y, 0);
            green.transform.position = new Vector3(x, y, 0);
            red.transform.position = new Vector3(x, y, 0);
            white.transform.position = new Vector3(x, y, 0);
            yellow.transform.position = new Vector3(x, y, 0);
            if (p.PlayerColor.Name.Equals(PlayerColor.BLACK.Name))
            {
                black = GameObject.Instantiate(black);
            }
            if (p.PlayerColor.Name.Equals(PlayerColor.BLUE.Name))
            {
                blue = GameObject.Instantiate(black);
            }
            if (p.PlayerColor.Name.Equals(PlayerColor.GREEN.Name))
            {
                green = GameObject.Instantiate(black);
            }
            if (p.PlayerColor.Name.Equals(PlayerColor.RED.Name))
            {
                red = GameObject.Instantiate(black);
            }
            if (p.PlayerColor.Name.Equals(PlayerColor.WHITE.Name))
            {
                white = GameObject.Instantiate(black);
            }
            if (p.PlayerColor.Name.Equals(PlayerColor.YELLOW.Name))
            {
                yellow = GameObject.Instantiate(black);
            }
        }
    }

    public void ChangeState(StateEnum state)
    {
        currentState = state;
    }

    public void ChangeState()
    {
        switch (currentState)
        {
            case StateEnum.ON_START:
                currentState = StateEnum.ON_JOIN_PRESSED;
                break;
            case StateEnum.ON_JOIN_PRESSED:
                currentState = StateEnum.ON_CONNECTING;
                break;
            case StateEnum.ON_CONNECTING:
                currentState = StateEnum.ON_CONNECTED;
                break;
            case StateEnum.ON_CONNECTED:
                currentState = StateEnum.ON_START_PRESSED;
                break;
            case StateEnum.ON_START_PRESSED:
                currentState = StateEnum.ON_PLAYERS_CREATION;
                break;
            case StateEnum.ON_PLAYERS_CREATION:
                currentState = StateEnum.ON_GAME;
                break;
            case StateEnum.ON_GAME:
                currentState = StateEnum.ON_GAME_OVER;
                break;
        }
    }

}
