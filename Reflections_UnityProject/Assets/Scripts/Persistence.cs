using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Persistence : MonoBehaviour {


    public static bool option_FullScreen;
    [SerializeField] private int highscore;
    [SerializeField] private bool unlock1;
    [SerializeField] private bool unlock2;
    [SerializeField] private bool unlock3;
    public static int publicscore;


    new public static AudioSource audio;

    private static bool created = false;

    // Use this for initialization
    void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
            audio = GetComponent<AudioSource>();
        }    
        else if(created)
        {
            Destroy(this.gameObject);
        }
    }
	// Update is called once per frame
	void Update ()
    {
        UpDateHighScore();
    }

    private void UpDateHighScore()
    {
        if (GameManager.Instance.PlayerisDead && GameManager.Instance.Score > highscore)
        {
            highscore = GameManager.Instance.Score;
            publicscore = highscore;
        }
        
    }

    public void UpDateVolume(float value)
    {
        audio.volume = value;
    }


}
