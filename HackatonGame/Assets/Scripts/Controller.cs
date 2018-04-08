using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    int i = 0;
    GameObject GO;
    public MiniGameCrash _MGC;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool TestModel(GameObject hunter)
    { 
            GO = hunter;
            CheckTest();
            return true;
    }

    public void CheckTest()
    {
        _MGC.Swipes(GO);
    }

    public void CheckCrach()
    {
        i = 0;
    }
}
