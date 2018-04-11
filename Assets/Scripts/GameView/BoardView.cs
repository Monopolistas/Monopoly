using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardView : MonoBehaviour
{

    GameStateMachine gameStateMachine;

    public GameController gameController;

    bool playersCreated = false;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStateMachine != null && gameStateMachine.Board.PlayerList.Count > 0 && !playersCreated)
        {
            for (int index = 0; index < gameStateMachine.Board.PlayerList.Count; index++)
            {
                Player player = gameStateMachine.Board.PlayerList[index];
                playersCreated = true;
                if (player.PlayerColor.Name.Equals(PlayerColor.BLACK.Name))
                {
                    GameObject.Instantiate(Resources.Load("Prefab/black"));
                }
                if (player.PlayerColor.Name.Equals(PlayerColor.WHITE.Name))
                {
                    GameObject.Instantiate(Resources.Load("Prefab/white"));
                }
                if (player.PlayerColor.Name.Equals(PlayerColor.RED.Name))
                {
                    GameObject.Instantiate(Resources.Load("Prefab/red"));
                }
                if (player.PlayerColor.Name.Equals(PlayerColor.GREEN.Name))
                {
                    GameObject.Instantiate(Resources.Load("Prefab/green"));
                }
                if (player.PlayerColor.Name.Equals(PlayerColor.BLUE.Name))
                {
                    GameObject.Instantiate(Resources.Load("Prefab/blue"));
                }
                if (player.PlayerColor.Name.Equals(PlayerColor.YELLOW.Name))
                {
                    GameObject.Instantiate(Resources.Load("Prefab/yellow"));
                }
            }
        }
        else
        {
            gameStateMachine = gameController.gameStateMachine;
        }
    }
}
