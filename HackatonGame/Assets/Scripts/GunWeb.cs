using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunWeb : MonoBehaviour {

    public Vector3 targetVector;

    private void Update()
    {
        transform.position += targetVector * 0.1f;
    }
}
