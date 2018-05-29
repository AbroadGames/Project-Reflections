using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TimeManager : MonoBehaviour
{

    public float slowmoFactor;
    public float slowmoLength;
	
	// Update is called once per frame
	void Update ()
    {
        Time.timeScale += (1f / slowmoLength) * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);

      
            
    }

    public void StartSlowmo ()
    {
        Time.timeScale = slowmoFactor;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }
}
