using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunWeb : MonoBehaviour {

    Vector3 targetVector;

    private void Update()
    {
        transform.position += new Vector3(-1,1,0) * 0.05f;
    }
}
