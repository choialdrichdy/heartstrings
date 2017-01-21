using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

	private float TIME_COUNTER = 10f; // Load next scene after this countdown
	//AudioSource bgMusic;
	private string currentSceneName;

	void Start () {
	 	currentSceneName = SceneManager.GetActiveScene ().name; // Get the current scene name
		Debug.Log ("Current scene is: "+currentSceneName); //Print the current scene name for debugging purposes
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log ("Current time is:"+Time.time);
		if (Time.time > TIME_COUNTER) {
			Debug.Log ("Current time is:"+Time.time+ " so we're loading the next scene...");
			LoadNextScene ();
		}
	}

	public void LoadNextScene () {
		/**if (bgMusic.isPlaying) {
			bgMusic.Stop ();
		}**/ //Stop the music, just in case.
		string sceneToLoad;
		if (currentSceneName == "0_CutScene") {
			sceneToLoad = "Scenes/MainGame";
		} else if (currentSceneName == "1_CutScene") {
			sceneToLoad = "Scenes/SecondGame";
		} else if (currentSceneName == "2_CutScene") {
			sceneToLoad = "Scenes/ThirdGame";
		} else {
			sceneToLoad = "Scenes/Start_Scene";
			PlayerPrefs.DeleteAll();
			Debug.Log ("This should be the end scene! So we start the game again...");
		}
		Debug.Log ("Loading the next scene: "+sceneToLoad);
		SceneManager.LoadScene (sceneToLoad, LoadSceneMode.Single);
	}
}
		
