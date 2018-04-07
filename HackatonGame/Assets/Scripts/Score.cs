using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public int score = 0;
	public Text text;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		}
	void OnTriggerEnter(Collider scoreTrigger)
	{
		if (scoreTrigger.tag == "ShortTrain") 
			score = score + 10;
			text.text = "score: " + score;

	}
}
