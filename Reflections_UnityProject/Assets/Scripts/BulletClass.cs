using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletClass : MonoBehaviour {

    public int speed;
    public bool isRefelcted = false;
    private GameObject target;

    // Use this for initialization
    void Start ()
    {
        target = GameObject.FindGameObjectWithTag("Player");

        Vector2 dir = target.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
	
	
}
