using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTracking : MonoBehaviour {

    //Varribles
    [SerializeField] private int localScore;
    [SerializeField] private Text score;
     
	// Use this for initialization
	void Start ()
    {
        localScore = 0;
        score = gameObject.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(GameManager.Instance.PlayerisDead == false)
        {
            localScore = (Mathf.RoundToInt(Time.time * 10));
 
        }
        score.text = localScore.ToString();

        GameManager.Instance.Score = localScore;
    }
}
