using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunWeb : MonoBehaviour {

    public Vector3 targetVector;
    public float timeToDestroy = 5;
    private float lifeTime = 0;


    private void Update()
    {
        transform.position += targetVector * 0.1f;
        lifeTime += Time.deltaTime;
        if(lifeTime > timeToDestroy)
        {
            Destroy(this.gameObject);
        }
    }
}
