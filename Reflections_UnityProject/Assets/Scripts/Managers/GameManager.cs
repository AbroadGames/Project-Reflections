using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
     public int PlayerSlows { get; set; }

    //Methods 

    private void Start()
    {
        Score = 0;
        PlayerisDead = false;
        PlayerSlows = 1;
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.Escape)) // Quit
        {
            SceneManager.LoadScene(0);
        }

        if (Input.GetKeyDown(KeyCode.R)) // Restart Scene
        {
            SceneManager.LoadScene(1);

        }

       
        if (PlayerisDead == false) // Score Calculation
        {
            Score = (Mathf.RoundToInt(Time.timeSinceLevelLoad * 10));
        }
        
        

    }


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
