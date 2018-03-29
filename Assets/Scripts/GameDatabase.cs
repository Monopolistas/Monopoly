using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDatabase : MonoBehaviour {

    ResourcesLoader resourcesLoader;

	// Use this for initialization
	void Start () {
        resourcesLoader = new ResourcesLoader();
        resourcesLoader.FillDatabase();
	}

}
