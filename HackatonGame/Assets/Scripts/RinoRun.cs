using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RinoRun : MonoBehaviour {

    public float speed = 2.0f;

    private bool canRun = true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(canRun)
        {
            transform.Translate(new Vector3(0, 1 * speed, 0));
        }
	}

    public void Gotcha()
    {
        canRun = false;
    }

    public bool isCanRun()
    {
        return canRun;
    }
}
