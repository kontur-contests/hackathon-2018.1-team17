using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhinoSpriteCatch : MonoBehaviour {

    public GameObject CatchTheRino;
    public GameObject Area;
	
    public void ChangeIt()
    {
        Area.SetActive(false);
        GetComponent<MeshRenderer>().enabled = false;
        Instantiate(CatchTheRino, new Vector3(this.transform.position.x, this.transform.position.y+2, this.transform.position.z), Quaternion.identity);
    }
}
