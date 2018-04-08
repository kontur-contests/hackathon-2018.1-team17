using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchRhino : MonoBehaviour {

    public UIController _UC;
	// Use this for initialization
	void Start () {
		
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
			theCollision.gameObject.GetComponent<AudioSource> ().enabled = false;
            theCollision.gameObject.GetComponent<PlayerController>().ShowLose();
            Destroy(this.gameObject);
        }
    }


}
