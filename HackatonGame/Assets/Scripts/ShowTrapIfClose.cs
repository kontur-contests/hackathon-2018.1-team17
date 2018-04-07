using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTrapIfClose : MonoBehaviour {

    public Transform rhino;
    Color C;
	// Use this for initialization
	void Start () {
        C = GetComponent<SpriteRenderer>().color;
        rhino = GameObject.Find("rhino").transform;
        //InvokeRepeating("CheckDistance", 2, 2);
    }
	
	// Update is called once per frame
	void Update () {
        CheckDistance();
	}

    public void CheckDistance()
    {        
        float Dist = 1 - Vector3.Distance(this.transform.position, rhino.transform.position)/20;
        C.a = Mathf.Max(Dist, 0);
        this.GetComponent<SpriteRenderer>().color = C;
        Debug.Log(Dist);
    }
}
