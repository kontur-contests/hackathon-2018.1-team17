using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RinoSpeedChange : MonoBehaviour {

    public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.A))
        {
            SpeedUp();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            SpeedDown();
        }
        transform.Translate(Vector3.up * speed);
	}

    public void SpeedUp()
    {
        speed *= 2;
        Invoke("SpeedNormal", 2);
    }

    public void SpeedDown()
    {
        speed /= 2;
        Invoke("SpeedNormal", 2);
    }

    public void SpeedNormal()
    {
        speed = -0.5f;
    }
}
