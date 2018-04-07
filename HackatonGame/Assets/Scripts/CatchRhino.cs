using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchRhino : MonoBehaviour {

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
            Destroy(this.gameObject);
        }
    }


}
