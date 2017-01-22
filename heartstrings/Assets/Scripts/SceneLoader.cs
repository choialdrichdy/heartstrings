using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

	private float TIME_COUNTER = 10f; // Load next scene after this countdown
	private bool IS_PLAYING;
	private float fadeTime;
	private Fading fadingClass;
	//AudioSource bgMusic;
	private string currentSceneName;

	void Start () {
		IS_PLAYING = true;
		fadingClass = GameObject.Find ("SceneTransitionHandler").GetComponent<Fading> ();
		fadingClass.BeginFade (-1);
	 	currentSceneName = SceneManager.GetActiveScene ().name; // Get the current scene name
		Debug.Log ("SCENE LOADER initialized. Current scene is: "+currentSceneName); //Print the current scene name for debugging purposes
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log ("Current time is:"+Time.time);
		if (IS_PLAYING) {
			if (Time.time > TIME_COUNTER) {
				Debug.Log ("Current time is:" + Time.time + " so we're loading the next scene...");
				IS_PLAYING = false;
				LoadNextScene ();
			}
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
		StartCoroutine(ChangeScene(sceneToLoad));
	}

	IEnumerator ChangeScene (string sceneToLoad) {
		Debug.Log("Initiated the IEnumerator");
		//fade the game and load a new level
		fadeTime = fadingClass.BeginFade(1);		
		Debug.Log("Initiated the IEnumerator");
		Debug.Log("Waiting for:" + fadeTime + "Seconds");
		yield return new WaitForSeconds (fadeTime);
		Debug.Log("Wait done, loading " + sceneToLoad);
		SceneManager.LoadScene (sceneToLoad, LoadSceneMode.Single);
	}

}
		
