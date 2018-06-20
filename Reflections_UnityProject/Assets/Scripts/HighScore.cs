using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {

    [SerializeField] private Text lblHighscore;

    // Use this for initialization
    void Start ()
    {
        
        lblHighscore.text = Persistence.publicscore.ToString();

    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
