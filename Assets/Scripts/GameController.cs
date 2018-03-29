using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    GameStateMachine gameStateMachine;

    // Use this for initialization
    void Start()
    {
        gameStateMachine = new GameStateMachine();
    }

    // Update is called once per frame
    void Update()
    {
        gameStateMachine.ExecuteGameLogic();
    }

}
