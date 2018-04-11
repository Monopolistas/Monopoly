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

    public enum StateEnum
    {
        ON_START = 1,
        ON_JOIN_PRESSED = 2,
        ON_CONNECTING = 3,
        ON_CONNECTED = 4,
        ON_START_PRESSED = 5
    }

    GameStateMachine gameStateMachine;
    StateEnum currentState;

    // Use this for initialization
    void Start()
    {
        currentState = StateEnum.ON_START;
    }

    private void Update()
    {
        gameStateMachine = gameController.gameStateMachine;

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
                if (gameStateMachine.Database.PlayerDictionary.Count > 1)
                {
                    string names = "";
                    foreach (Player item in gameStateMachine.Database.PlayerDictionary.Values)
                    {
                        if (!item.Id.Equals(gameStateMachine.Owner.Id))
                        {
                            names += item.Name + "\n";
                        }
                    }
                    otherPlayersNameText.text = names;
                }
                break;
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
        }
    }

}
