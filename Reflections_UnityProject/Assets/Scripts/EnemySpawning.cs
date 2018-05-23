using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour {

    //varribles
    [SerializeField] private int localScore;
    public float respawnTime1;
    public bool respawnTime2 = false;
    public GameObject enemy;
    private Vector2 position;

    // Use this for initialization
    void Start ()
    {
  
        respawnTime1 = 1.5f;
   
    }

    

    // Update is called once per frame
    void Update ()
    {
        if (respawnTime2 == false)
        {
            Invoke("Spawn", respawnTime1);
            respawnTime2 = true;
        }
        

        localScore = GameManager.Instance.Score;
       
        Respawning();
       

    }

    private void Respawning()
    {

           
        if (localScore == 50)
        {
            respawnTime1 = 1f;
            
        }
        if (localScore == 100)
        {
            respawnTime1 = 0.7f;
            
        }
        if (localScore == 200)
        {
            respawnTime1 = 0.5f;
            
        }
        if (localScore == 300)
        {
            respawnTime1 = 0.3f;
            
        }
        if (localScore == 500)
        {
            respawnTime1 = 0.25f;
            
        }
    }


   


    private void Spawn()
    {
       

        Vector2 pos = Random.insideUnitCircle.normalized * 7;
        Invoke("SetRespawn2toFalse", 0.02f);

        Instantiate(enemy, pos, Quaternion.identity);    
        

    }

    private void SetRespawn2toFalse()
    {
        respawnTime2 = false;
    }

}
