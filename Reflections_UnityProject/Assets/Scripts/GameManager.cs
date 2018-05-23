using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Singleton Setup
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject gameObject = new GameObject("GameManager");
                gameObject.AddComponent<GameManager>();
            }

            return _instance;
        }
    }

    //Global Varribles

     public int Score { get; set; }
     public bool PlayerisDead { get; set; }
     public int CurrentEnemies { get; set; }
     public int MaxEnemies { get; set; }

    //Methods 

   
    public void GameOver()
    {
        Debug.Log("GameOver!!!");
    }

    public void KillPlayer()
    {
        PlayerisDead = true;  
    }


    private void Awake()
    {
        _instance = this;
        
    }
}
