using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public GameStateMachine gameStateMachine;

    // Use this before any start runs
    void Awake()
    {
        gameStateMachine = new GameStateMachine();
    }

    // Update is called once per frame
    void Update()
    {
        gameStateMachine.ExecuteGameLogic();
    }

}
