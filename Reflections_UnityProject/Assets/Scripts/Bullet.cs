using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {


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
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        
       if (isRefelcted == false)
        {
            
             GetComponent<Rigidbody2D>().velocity = transform.right * speed;
        }

    }

    void OnTriggerEnter2D(Collider2D other)

    {
        if(other.gameObject.tag == "Mirror")
        {
            SpriteRenderer sr = GetComponent<SpriteRenderer>();
            sr.color = Color.gray;

            GetComponent<Rigidbody2D>().velocity = Vector2.Reflect(transform.position, other.transform.up) * speed;



            isRefelcted = true;
            gameObject.tag = "Reflected";
        }
        
    }
}
