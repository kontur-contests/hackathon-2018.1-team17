using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainIsNear : MonoBehaviour {

    public Transform Train;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Train.GetComponent<SpriteRenderer>().sortingLayerName = "Front";
        }
    }
}
