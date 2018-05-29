using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    //Varribles
  
    [SerializeField] private Text score;
    [SerializeField] private Text slows; //temp
     

	// Update is called once per frame
	void Update ()
    {
        
        score.text = GameManager.Instance.Score.ToString();
        slows.text = GameManager.Instance.PlayerSlows.ToString();

    }
}
