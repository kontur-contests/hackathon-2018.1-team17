using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HausScript : MonoBehaviour {


    private GameObject crashed;
    private GameObject canvas;

    // Use this for initialization
    void Start()
    {
        crashed = transform.Find("crashed").gameObject;
        canvas = GameObject.Find("MyCan").gameObject;
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
			crashed.GetComponent<AudioSource> ().enabled = true;
            crashed.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);

            canvas.GetComponent<UIController>().AddScore();
        }
        else if (theCollision.gameObject.name.Contains("rhino"))
        {
            RinoRun rinoRun = theCollision.gameObject.GetComponent<RinoRun>();
            if (!rinoRun.isCanRun())
            {
                return;
            }
            crashed.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            canvas.GetComponent<UIController>().AddScore();
            GameObject Canvass = GameObject.Find("MyCan").gameObject;
            Canvass.GetComponent<UIController>().AddScore();
        }
    }
}
