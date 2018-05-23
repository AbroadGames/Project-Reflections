using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {


    public int speed;
    public bool isRefelcted = false;
    private GameObject other;
   
    // Use this for initialization
    void Start ()
    {
        

        
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
       if (isRefelcted == false)
        {
            // GetComponent<Rigidbody2D>().AddForce(transform.right * speed, ForceMode2D.Force);
             GetComponent<Rigidbody2D>().velocity = transform.right * speed;
        }
        if (isRefelcted == true)
        {
            // GetComponent<Rigidbody2D>().AddForce(-transform.right * speed, ForceMode2D.Force);

            GetComponent<Rigidbody2D>().velocity = -transform.right * speed;
            

        }

    }

    void OnTriggerEnter2D(Collider2D other)

    {
        if(other.gameObject.tag == "Mirror")
        {
           

            isRefelcted = true;
            gameObject.tag = "Reflected";
        }
        
    }
}
