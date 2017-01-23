using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class moveBG : MonoBehaviour {
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float timeScale;
        if (SceneManager.GetActiveScene().name.Equals("MainGame"))
        {
            timeScale = 3.5f;
        }
        else if (SceneManager.GetActiveScene().name.Equals("SecondGame"))
        {
            timeScale = 3.5f * (140.0f / 120);
        }
        else
        {
            timeScale = 45f;
        }
        transform.Translate(new Vector3(0.01f*(timeScale / 3.5f), 0.0f, 0.0f));
	}
}
