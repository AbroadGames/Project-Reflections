using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour {

    //Varribles
    public GameObject pivot;
    private Vector3 v3Pos;
    private float angle;
    public float range = 2f;


    private void MirrorRotation()
    {
        v3Pos = Input.mousePosition;
        v3Pos.z = (pivot.transform.position.z - Camera.main.transform.position.z);
        v3Pos = Camera.main.ScreenToWorldPoint(v3Pos);
        v3Pos = v3Pos - pivot.transform.position;
        angle = Mathf.Atan2(v3Pos.y, v3Pos.x) * Mathf.Rad2Deg;
        if (angle < 0) angle += 360;
        transform.localEulerAngles = new Vector3(0, 0, angle);
        float xPos = Mathf.Cos(Mathf.Deg2Rad * angle) * range;
        float yPos = Mathf.Sin(Mathf.Deg2Rad * angle) * range;
        transform.localPosition = new Vector3(pivot.transform.position.x + xPos * 4, pivot.transform.position.y + yPos * 4, 0);
    }


    // Use this for initialization
    void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        MirrorRotation();

    }
}
