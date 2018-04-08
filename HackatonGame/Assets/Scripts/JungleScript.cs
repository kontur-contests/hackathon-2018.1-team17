using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JungleScript : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnEnter2D(Collision2D theCollision)
    {
        Debug.Log("Junglee!");
        if (theCollision.gameObject.name.Contains("rhino"))
        {
            Debug.Log("You win!");
        }
    }
}
