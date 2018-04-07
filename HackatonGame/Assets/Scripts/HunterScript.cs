using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterScript : MonoBehaviour {

    public Transform rhino;


    public float speed = 2.5f;

    public float distanceRequiredForContact = 3;

    private int huntStage = 0; //0 - догнать, 1 - поймать

    public float timeForCatchingRequired = 2;
    private float timeTilCatching = 0;

    // Use this for initialization
    void Start () {
        rhino = GameObject.Find("rhino").transform;
    }
	
	// Update is called once per frame
	void Update () {
		switch(huntStage)
        {
            case 0:
                {
                    DecreaseDistancence();
                    break;
                }
            case 1:
                {
                    Catching();
                    break;
                }
        }
	}

    void DecreaseDistancence()
    {
        Vector3 delta = rhino.position - transform.position;
        delta.Normalize();
        float moveSpeed = speed * Time.deltaTime;
        transform.position = transform.position + (delta * moveSpeed);
    }

    bool IsInContact()
    {
        return Vector3.Distance(transform.position, rhino.transform.position) <= distanceRequiredForContact;
    }

    void OnCollisionEnter2D(Collision2D theCollision)
    {
        //Проверяем коллизию с объектом типа «rhino»
        if (theCollision.gameObject.name.Contains("rhino"))
        {
            switch(huntStage)
            {
                case 0:
                    {
                        StartCatching();
                        break;
                    }
            }
        }
    }

    void StartCatching()
    {
        huntStage = 1;
        timeTilCatching = 0;
    }

    void Catching()
    {
        if(timeTilCatching > timeForCatchingRequired)
        {
            Gotcha();
            return;
        }
        if(!this.IsInContact())
        {
            huntStage = 0;
            return;
        }
        DecreaseDistancence();
        timeTilCatching += Time.deltaTime;
    }

    void Gotcha()
    {
        RinoRun rhinoRun = this.rhino.GetComponent("RinoScript") as RinoRun;
        rhinoRun.Gotcha();
        huntStage = 2;
    }
}
