using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyClass : MonoBehaviour {

    private GameObject target;

    public GameObject bullet;

    public GameObject emiter;

    public float cooldown;

    public float warmup;
    
    void Start()
    {
        //Look at Target on start
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 dir = target.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        StartCoroutine(ShootCoroutine(warmup));
    }

    private void Update()
    {

    }

    IEnumerator ShootCoroutine(float warmup)
    {
        if (warmup != 0)
        {
            yield return new WaitForSeconds(warmup);
        }

        while (GameManager.Instance.PlayerisDead == false)
        {
            FireBullet();
            yield return new WaitForSeconds(cooldown);
        }

        yield return null;
    }

    public void FireBullet()
    {

        Instantiate(bullet, transform.position, transform.rotation);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Reflected")
        {
            Destroy(gameObject);
        }
    }
   
	
	
}
