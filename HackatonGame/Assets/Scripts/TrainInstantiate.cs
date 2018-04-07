using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainInstantiate : MonoBehaviour {
	
	public GameObject trainTrigger;
	public List <GameObject> trainList;
	private Object trList;
	// Use this for initialization
	void Start () {
		trList = trainList [Random.Range (0, 2)];
		Instantiate (trList);
	}
	
	// Update is called once per frame
	void Update () {

	}
	/*void OnTriggerEnter(Collider trainTrigger){
	Instantiate(longTrain);
	}*/

}
