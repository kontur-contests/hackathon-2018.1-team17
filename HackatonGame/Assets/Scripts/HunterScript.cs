using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterScript : MonoBehaviour {

    public Transform rhino;
    public Transform player;
    public Transform catcher;
    private Transform center;

    public float speed = 2.5f;

    public float distanceRequiredForContact = 3;

    private int huntStage = 0; //0 - догнать, 1 - поймать

    public float timeForCatchingRequired;
    private float timeTilCatching = 0;
    private Vector3 target;
    private Vector3 alternativeTarget = Vector3.zero;



    // Use this for initialization
    void Start () {
        player = GameObject.Find("player").transform;
        rhino = player.transform.Find("rhino").transform;
        catcher = this.transform.Find("catcher");
        Vector3 size = rhino.GetComponent<BoxCollider2D>().size;
        float x = Mathf.Sign(transform.position.x) * 4 * size.x;
        float y = 3f*size.y;
        target = new Vector3(x, y, 0);
        if(x >= 0)
        {
            catcher.transform.Rotate(0, 0, -45);
        } else
        {
            catcher.transform.Rotate(0, 0, 135);
        }
    }
	
	// Update is called once per frame
	void Update () {
       // transform.Rotate(0, 0, transform.rotation.z/2) ;
        Vector3 rhinoPosition = player.TransformVector(rhino.position);
        if (alternativeTarget.Equals(Vector3.zero))
        {
            DecreaseDistancence(rhinoPosition);
            if(IsInContact())
            {
                StartCatching();
            }
        } else
        {
            if (Vector3.Distance(rhinoPosition, transform.position) > 2 * distanceRequiredForContact)
            {
                alternativeTarget = Vector3.zero;
                return;
            }
            DecreaseDistancence(alternativeTarget);
        }
	}

    void DecreaseDistancence(Vector3 position)
    {
        Vector3 delta = position - transform.position + target;
        delta.Normalize();
        float moveSpeed = speed * Time.deltaTime;
        transform.Translate(delta.x*moveSpeed, delta.y*moveSpeed, 0);

        //RotateCatcher();
        
    }

    void RotateCatcher()
    {
        Vector3 dV = transform.position - rhino.position;
        float angle = Mathf.Atan2(dV.y, dV.x) * Mathf.Rad2Deg * 2 + 45;
        Quaternion rot = Quaternion.Euler(new Vector3(0, 0, angle));
        catcher.transform.rotation = rot;
    }

    bool IsInContact()
    {
        Vector3 pos = player.TransformVector(rhino.position + target);
        return Vector3.Distance(pos, this.transform.position) < distanceRequiredForContact;
    }

    void OnCollisionEnter2D(Collision2D theCollision)
    {
        //Проверяем коллизию с объектом типа «rhino»
        if (theCollision.gameObject.name.Contains("rhino"))
        {
            StartCatching();
        }
    }

    void StartCatching()
    {
        alternativeTarget = new Vector3(5 * Mathf.Sign(transform.position.x), transform.position.y - 5, 0);
        Shooting shooting = this.catcher.GetComponent("Shooting") as Shooting;
        shooting.Shoot();
    }

    void Catching()
    {
        if(timeTilCatching > timeForCatchingRequired)
        {
            Gotcha();
            return;
        }
        if(!this.IsInContact())
        {
            huntStage = 0;
            return;
        }
        DecreaseDistancence(rhino.transform.position);
        timeTilCatching += Time.deltaTime;
    }

    void Gotcha()
    {
        RinoRun rhinoRun = this.rhino.GetComponent("RinoScript") as RinoRun;
        rhinoRun.Gotcha();
        huntStage = 2;
    }
}
