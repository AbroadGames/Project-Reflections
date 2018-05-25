using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour {

    //varribles
    [SerializeField] private int localScore;
    public float respawnTime1;
    public bool respawnTime2 = false;
    public bool respawnTime4 = false;
    public GameObject enemy;
    public GameObject bullet;
    private Vector2 position;
    

    // Use this for initialization
    void Start ()
    {
  
        respawnTime1 = 1.5f;
        
    }

    

    // Update is called once per frame
    void Update ()
    {
        if (GameManager.Instance.PlayerisDead == false)
        {
            if (respawnTime4 == false)
            {
                Invoke("SpawnEnemy", respawnTime1 * 4);
                respawnTime4 = true;
            }
            if (respawnTime2 == false)
            {
                Invoke("SpawnBullet", respawnTime1);
                respawnTime2 = true;
            }
            Respawning();
        }
           
        

        localScore = GameManager.Instance.Score;
   

    }

    private void Respawning()
    {

           
        if (localScore == 50)
        {
            respawnTime1 = 1.5f;
            
        }
        if (localScore == 100)
        {
            respawnTime1 = 1f;
            
        }
        if (localScore == 200)
        {
            respawnTime1 = 0.7f;
            
        }
        if (localScore == 300)
        {
            respawnTime1 = 0.5f;
            
        }
        if (localScore == 500)
        {
            respawnTime1 = 0.3f;
            
        }
    }


   


    private void SpawnBullet()
    {
   
        Vector2 pos = Random.insideUnitCircle.normalized * 12;
        Invoke("SetRespawn2toFalse", 0.02f);

        GameObject bulletInstance = Instantiate(bullet, pos, Quaternion.identity);
        Destroy(bulletInstance, 5);

    }

    private void SpawnEnemy()
    {

        Vector2 pos = Random.insideUnitCircle.normalized * 7;
        Invoke("SetRespawn4toFalse", 2f);

        Instantiate(enemy, pos, Quaternion.identity);
        
    }

    private void SetRespawn2toFalse()
    {
        respawnTime2 = false;
    }

    private void SetRespawn4toFalse()
    {
        respawnTime4 = false;
    }

}
