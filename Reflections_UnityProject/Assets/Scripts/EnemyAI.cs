using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{


    private GameObject target;

    public GameObject bullet;

    public GameObject emiter;

    public bool WeaponCoolDown = true;

    public float cooldown = 0.2f;

    
    // Update is called once per frame
    void Start()
    {
        //Look at Target on start
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 dir = target.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        Invoke("WeaponCoolDownOver", cooldown);

    }

    private void Update()
    {
        

        

        if (WeaponCoolDown == false && GameManager.Instance.PlayerisDead == false)
        {
            WeaponCoolDown = true;

            FireBullet();

            Invoke("WeaponCoolDownOver", cooldown);
        }
    }

    public void WeaponCoolDownOver()
    {
        WeaponCoolDown = false;
    }

    public void FireBullet()
    {

        Instantiate(bullet, transform.position, transform.rotation);

      
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Reflected" )
        {
            Destroy(gameObject);
        }
    }

}
