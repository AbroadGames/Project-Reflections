using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowBullet : BulletClass
{

    void FixedUpdate()
    {

        if (isRefelcted == false)
        {
            GetComponent<Rigidbody2D>().velocity = transform.right * speed;
        }

    }

    void OnTriggerEnter2D(Collider2D other)

    {
        if (other.gameObject.tag == "Mirror")
        {
            SpriteRenderer sr = GetComponent<SpriteRenderer>();
            sr.color = Color.yellow;

            GetComponent<Rigidbody2D>().velocity = Vector2.Reflect(transform.position, other.transform.up) * speed;

            isRefelcted = true;
            gameObject.tag = "Mirror";
            
        }

    }
}
