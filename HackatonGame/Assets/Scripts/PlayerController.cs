using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float rotatespeed;
    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetKey(KeyCode.Z))
        {
            transform.Translate(new Vector3(1 * -rotatespeed, 0, 0));
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {            
            LeftRun();
        }

        if (Input.GetKeyUp(KeyCode.Z))
        {
            StopLeftRun();
        }

        if (Input.GetKey(KeyCode.X))
        {
            transform.Translate(new Vector3(1 * rotatespeed, 0, 0));
        }

        if (Input.GetKeyDown(KeyCode.X))
        {            
            RightRun();
        }

        if (Input.GetKeyUp(KeyCode.X))
        {
            StopRightRun();
        }

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
        speed = 1.01f;
    }

    public void LeftRun()
    {
        GetComponent<Animator>().SetBool("Left",true);
    }

    public void RunForward()
    {
        GetComponent<Animator>().SetBool("Run", true);
        GetComponent<Animator>().SetBool("Left", false);
        GetComponent<Animator>().SetBool("Right", false);
    }

    public void StopLeftRun()
    {
        GetComponent<Animator>().SetBool("Left", false);
    }

    public void StopRightRun()
    {
        GetComponent<Animator>().SetBool("Right", false);
    }

    public void RightRun()
    {
        GetComponent<Animator>().SetBool("Right", true);
    }
}
