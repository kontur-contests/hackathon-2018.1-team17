using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainTriggerScript : MonoBehaviour {

    public List<GameObject> traines;
    public float trainDistance = 30;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D theCollision)
    {
        if (theCollision.gameObject.name.Contains("rhino"))
        {
            Destroy(this.gameObject);
            GameObject train = traines[Random.Range(0, traines.Count)];
            Instantiate(train, new Vector3(0, this.transform.position.y + trainDistance, 0), Quaternion.identity);
        }
    }
}
