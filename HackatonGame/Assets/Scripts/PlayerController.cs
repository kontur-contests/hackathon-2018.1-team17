using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float rotatespeed;
	public Button speedUpButton;
	public Button speedDownButton;
	public float notError;
    // Use this for initialization
    void Start ()
    {
		StartCoroutine(ForSpeedUp());
		StartCoroutine(ForSpeedDown());
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
	IEnumerator ForSpeedUp()
	{
		yield return new WaitForSeconds (10);
		speedUpButton.enabled = true;
	}
	IEnumerator ForSpeedDown()
	{
		yield return new WaitForSeconds (10);
		speedDownButton.enabled = true;
	}
    public void SpeedUp()
    {
        speed *= 2;
        Invoke("SpeedNormal", 2);
		speedUpButton.enabled = false;
		ForSpeedUp ();

    }

    public void SpeedDown()
    {
        speed /= 2;
        Invoke("SpeedNormal", 2);
		speedDownButton.enabled = false;
		ForSpeedDown ();
    }

    public void SpeedNormal()
    {
		speed = notError;
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
	public void Exit(){
			SceneManager.LoadScene ("StartMenu");
	}
}
