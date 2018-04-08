using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameCrash : MonoBehaviour {

    public Text texst;

    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;
    int Test = 99;
    bool checkDanger = false;
    float timer;
    GameObject GO1;
    public Controller _C;
	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.touches.Length > 0 && checkDanger)
        {
            timer += Time.deltaTime;
            if (timer > 1.2f)
                BadStep();
            Touch t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Began)
            {
                firstPressPos = new Vector2(t.position.x, t.position.y);
            }

            if (t.phase == TouchPhase.Ended)
            {
                secondPressPos = new Vector2(t.position.x, t.position.y);

                currentSwipe = new Vector3(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

                currentSwipe.Normalize();

                if (currentSwipe.x > 0 && Test==0)
                {
                    NextStep();
                    return;
                }
                if (currentSwipe.x < 0 && Test==1)
                {
                    NextStep();
                    return;
                }

                if (currentSwipe.x > 0 && Test == 2)
                {
                    EndStep();
                    return;
                }
                if (currentSwipe.x < 0 && Test == 3)
                {
                    EndStep();
                    return;
                }
                BadStep();
            }
        }
    }

    public void BadStep()
    {
        texst.text = "Looser!";
        checkDanger = false;
    }

    public void Swipes(GameObject hunter)
    {
        checkDanger = true;
        GO1 = hunter;
        int j = Random.Range(0, 2);
        if (j == 0)
        {
            Test = 0;
            texst.text = "Swipe Right!";
        }

        if (j == 1)
        {
            Test = 1;
            texst.text = "Swipe Left!";
        }
    }

    public void NextStep()
    {
        int j = Random.Range(2, 4);
        if (j == 2)
        {
            Test = 0;
            texst.text = "Swipe Right!";
        }

        if (j == 3)
        {
            Test = 1;
            texst.text = "Swipe Left!";
        }
    }

    public void EndStep()
    {
        texst.text = "Well Played!";
        checkDanger = false;
        HunterScript hunterScript = GO1.gameObject.GetComponent("HunterScript") as HunterScript;
        hunterScript.Crash();
        GameObject crashed = hunterScript.transform.Find("crashed").gameObject;
        crashed.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        GameObject Canvass = GameObject.Find("MyCan").gameObject;
        Canvass.GetComponent<UIController>().AddScore();
        _C.CheckCrach();
    }
}
