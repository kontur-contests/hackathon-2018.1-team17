using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainInstantiate : MonoBehaviour {
	
	//	public GameObject trainTrigger;
	public List <GameObject> trainList1;
	private Object trList1;
	public List <GameObject> trainList2;
	private Object trList2;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}
	void GoTreain (Vector3 target){
		trList = trainList1 [Random.Range (0, 2)];
		Instantiate (trList);
	}
	void GoTreain2 (Vector3 target){
		trList2 = trainList2 [Random.Range (0, 2)];
		Instantiate (trList2);
	}

	void OnTriggerEnter(Collider trainTrigger){
		if (trainTrigger.tag == "TrainTrigger")
			GoTreain (this.transform.position);
		if (trainTrigger.tag == "TrainTrigger2")
			GoTreain2 (this.transform.position);
	}
}
