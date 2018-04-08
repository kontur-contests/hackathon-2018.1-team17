using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HausScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnCollisionEnter2D(Collision2D theCollision)
    {
        if (theCollision.gameObject.name.Contains("hunter"))
        {
            //Destroy(this.gameObject);
            HunterScript hunterScript = theCollision.gameObject.GetComponent("HunterScript") as HunterScript;
            hunterScript.Crash();
            GameObject crashed = transform.Find("crashed").gameObject;
            crashed.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        }
    }
}
