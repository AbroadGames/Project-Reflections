using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour

{
    public float speed;
    public Rigidbody2D rb;

    private void PlayerMovement()
    {
        //Z rotation based on main cammera and mouse position
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 dir = Input.mousePosition - pos;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        //movement :/
        float input_x = Input.GetAxisRaw("Horizontal");
        float input_y = Input.GetAxisRaw("Vertical");

        rb.position += new Vector2(input_x, input_y).normalized * speed * Time.deltaTime;

    }


    private void AmDead()
    {
        if (GameManager.Instance.PlayerisDead == true)
        {
            Destroy(gameObject);
        }
    }
        




    // Use this for initialization
    void Start ()
    {
        GameManager.Instance.PlayerisDead = false;
        

        
	}
	
	// Update is called once per frame
	void Update ()
    {
        PlayerMovement();


        if (Input.GetKey(KeyCode.Escape)) // quit temp
        {
            Application.Quit();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Reflected")
        {
            return;
        }
        else
        {
            GameManager.Instance.KillPlayer();
            AmDead();
        }
    }

}
