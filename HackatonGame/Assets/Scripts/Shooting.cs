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
        
    }

    public void Shoot()
    {
        GameObject prefab;
        float x = (transform.position.x >= 0) ? -1 : 1;
        float y = 0f;
        prefab = Instantiate(FromGun, this.gameObject.transform.position - new Vector3(-0.5f*x, y - 0.5f, 0), this.transform.parent.rotation);
        GunWeb gunWeb = prefab.GetComponent<GunWeb>();
        gunWeb.targetVector = new Vector3(x, y, 0);
    }
}
