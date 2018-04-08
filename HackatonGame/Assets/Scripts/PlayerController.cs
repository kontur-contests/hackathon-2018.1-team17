using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float rotatespeed;
    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;
    bool blockFastSpeed = false;
    bool blockSlowSpeed = false;
    public UIController _UIC;
    public float radius = 4;
    // Use this for initialization
    void Start ()
    {
		
	}
	// Update is called once per frame
	void Update ()
    {
#if UNITY_EDITOR
        if (Input.GetKey(KeyCode.Z))
        {
            if (transform.position.x < -radius)
            {
                return;
            }
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
            if (transform.position.x > radius)
            {
                return;
            }
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
#endif
#if UNITY_ANDROID
        if (Input.acceleration.x > 0)
        {
            if (transform.position.x > radius)
            {
                return;
            }
            transform.Translate(Input.acceleration.x/100, 0, 0);
            RightRun();
        }

        if (Input.acceleration.x < 0)
        {
            if (transform.position.x < -radius)
            {
                return;
            }
            transform.Translate(Input.acceleration.x/100, 0, 0);
            LeftRun();
        }

        if (Input.acceleration.x == 0)
        {
            StopLeftRun();
            StopRightRun();
        }

        if (Input.touches.Length > 0)
        {
            Touch t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Began)
            {
                firstPressPos = new Vector2(t.position.x, t.position.y);
            }

            if (t.phase == TouchPhase.Ended)
            {
                //save ended touch 2d point
                secondPressPos = new Vector2(t.position.x, t.position.y);

                //create vector from the two points
                currentSwipe = new Vector3(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

                //normalize the 2d vector
                currentSwipe.Normalize();

                //swipe upwards
                if (currentSwipe.y > 0 && !blockFastSpeed)
                {
                    SpeedUp();
                }
                //swipe down
                if (currentSwipe.y < 0 && !blockSlowSpeed)
                {
                    SpeedDown();
                }
            }
        }
        transform.Translate(Vector3.up * speed);
#endif
    }

    public void SpeedUp()
    {
        blockFastSpeed = true;
        GetComponentInParent<SpeedRinoParent>().speed *= 2;
        Invoke("SpeedNormal", 2);
        Invoke("DisableFastBlock", 5);
    }

    public void SpeedDown()
    {
        blockSlowSpeed = true;
        GetComponentInParent<SpeedRinoParent>().speed /= 2;
        Invoke("SpeedNormal", 2);
        Invoke("DisableSlowBlock", 5);
    }

    public void SpeedNormal()
    {
        GetComponentInParent<SpeedRinoParent>().speed = 0.04f;
    }

    public void DisableFastBlock()
    {
        blockFastSpeed = false;
    }

    public void DisableSlowBlock()
    {
        blockSlowSpeed = false;
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

    public void ShowLose()
    {
        _UIC.Lose();
    }

    public void ShowWin()
    {
        _UIC.Win();
    }
}
