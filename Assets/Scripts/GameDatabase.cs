using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDatabase : MonoBehaviour
{

    ResourcesLoader resourcesLoader;

    public GameController gameController;

    // Use this for initialization
    void Start()
    {
        resourcesLoader = new ResourcesLoader();

        resourcesLoader.GameStateMachine = gameController.gameStateMachine;

        resourcesLoader.LoadXmlDataFromUnity();

        resourcesLoader.FillDatabase();
    }

}
