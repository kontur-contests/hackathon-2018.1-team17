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
    }
	
	// Update is called once per frame
	void Update ()
    {
        var newRotation = Quaternion.LookRotation(transform.position - target.position, Vector3.forward);
        newRotation.x = 0.0f;
        newRotation.y = 0.0f;
        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 8);
    }

    public void Shoot()
    {
        GameObject prefab;
        prefab = Instantiate(FromGun, this.transform);
        prefab.GetComponent<GunWeb>().Force(Rino.transform.position);
    }
}
