using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTrapIfClose : MonoBehaviour {

    public GameObject Player;
    Color C;
	// Use this for initialization
	void Start () {
        C = GetComponent<SpriteRenderer>().color;
        //InvokeRepeating("CheckDistance", 2, 2);
    }
	
	// Update is called once per frame
	void Update () {
        CheckDistance();
	}

    public void CheckDistance()
    {        
        float Dist = 1 - Vector3.Distance(this.transform.position, Player.transform.position)/20;
        if (Dist < 0)
        {
            Dist = 0;
        }
        C.a = Dist;
        this.GetComponent<SpriteRenderer>().color = C;
        Debug.Log(Dist);
    }
}
