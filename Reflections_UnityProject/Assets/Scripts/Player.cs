using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour

{
    

    private void PlayerMovement()
    {
        //Z rotation based on main cammera and mouse position
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 dir = Input.mousePosition - pos;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
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
