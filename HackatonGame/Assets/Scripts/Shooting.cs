using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    public GameObject FromGun;
    public GameObject Rino;
    public Transform target;
    public float speed;
    // Use this for initialization
    void Start ()
    {
        InvokeRepeating("Shoot", 1, 3);
    }
	
	// Update is called once per frame
	void Update ()
    {
        
    }

    public void Shoot()
    {
        GameObject prefab;
        prefab = Instantiate(FromGun, this.gameObject.transform.position, Quaternion.identity);
    }
}
