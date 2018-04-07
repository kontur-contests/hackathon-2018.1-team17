using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunWeb : MonoBehaviour {

    Vector3 targetVector;

    private void Update()
    {
        Vector3.Lerp(this.transform.position, targetVector, 5);
    }

    public void Force(Vector3 target)
    {
        targetVector = target;
    }
}
