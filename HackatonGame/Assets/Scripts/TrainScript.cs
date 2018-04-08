using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainScript : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	

    private GameObject canvas;
    // Use this for initialization
    void Start()
    {
        canvas = GameObject.Find("MyCan").gameObject;
    }

	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D theCollision)
    {
        if (theCollision.gameObject.name.Contains("rhino"))
        {
            theCollision.gameObject.GetComponent<RhinoSpriteCatch>().ChangeIt();
            theCollision.gameObject.GetComponentInParent<SpeedRinoParent>().enabled = false;
            theCollision.gameObject.GetComponent<PlayerController>().ShowLose();

        }
        else if (theCollision.gameObject.name.Contains("hunter"))
        {
            //Destroy(this.gameObject);
            HunterScript hunterScript = theCollision.gameObject.GetComponent("HunterScript") as HunterScript;
            hunterScript.Crash();
            canvas.GetComponent<UIController>().AddScore();

        }
    }
}
