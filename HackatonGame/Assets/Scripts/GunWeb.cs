using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunWeb : MonoBehaviour {

    Vector3 targetVector;

    private void Update()
    {
        transform.position += Vector3.left * 0.1f;
    }
}
