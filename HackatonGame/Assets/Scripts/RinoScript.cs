using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RinoScript : MonoBehaviour {
    // Изменение скорости перемещения героя
    public float playerSpeed = 2.0f;

    // Текущая скорость перемещения
    private float currentSpeed = 0.0f;

    // Сохранение последнего перемещения
    private Vector3 lastTarget;

    private bool canRun = true;
    // Use this for initialization
    void Start () {
        lastTarget = RandomVector();
	}

    public void gotcha()
    {
        canRun = false;
    }

    private Vector3 RandomVector()
    {
        float x = Random.Range(0, 20) - 10;
        float y = Random.Range(0, 20) - 10;
        return new Vector3(x, y, 1);
    }


	// Update is called once per frame
	void Update () {
        if(canRun)
        {
            RedirectIfNeeded();
            MoveToTarget();
        }        
	}

    private void RedirectIfNeeded()
    {
        if (Vector3.Distance(this.transform.position, lastTarget) < 3)
        {
            lastTarget = RandomVector();
        }
    }

    private void MoveToTarget()
    {
        Vector3 movement = lastTarget - transform.position;
        movement.Normalize();
        this.transform.Translate(movement * Time.deltaTime * playerSpeed, Space.World);
    }
}
