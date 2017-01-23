using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoaderForGameSequences : MonoBehaviour {

	public float sceneTime = 45.0f;

	// This is a score out of 74!
	public int MIN_SCORE_FOR_GOOD = 60; 
	public int MIN_SCORE_FOR_NORMAL = 30;

	private float fadeTime;
	private bool IS_PLAYING;
	private Fading fadingClass;
	private string currentSceneName;

	/**
	 * Please invoke LoadNextScene(float sceneTime) to stop the current scene and load the next one. This script should handle all scene changes.
	 * @sceneTime - determines how long the scene will play until we move on to the next stage
	 * */

	/** Make a prefab, add a camera, attach SceneLoaderForGameSequences.cs to that camera
	*make an empty game object that is a child of the camera called SceneTransitionHandlerForGameSequences, attach Fading.cs to that object 
	* Make sure you add the black texture for Fading.cs
	*/ 


	//void Start (float sceneTimeTemp) {
	void Start () {
		//sceneTime = sceneTimeTemp;
		IS_PLAYING = true;
		fadingClass = GameObject.Find ("SceneTransitionHandlerForGameSequences").GetComponent<Fading> ();
		fadingClass.BeginFade (-1);
		currentSceneName = SceneManager.GetActiveScene ().name; // Get the current scene name
		Debug.Log ("SCENE LOADER initialized. Current scene is: "+currentSceneName); //Print the current scene name for debugging purposes
	}

	void Update () {
		Debug.Log ("Current time is:" + Time.timeSinceLevelLoad + IS_PLAYING + "?");
        Debug.Log(PlayerPrefs.GetInt("score"));
		if (IS_PLAYING) {
			if (Time.timeSinceLevelLoad > sceneTime) {
				//Debug.Log ("Current time is:" + Time.timeSinceLevelLoad + " so we're loading the next scene...");
				IS_PLAYING = false;
				LoadNextScene ();
			}
		}
	}

	public void LoadNextScene () {
		string sceneToLoad;
		if (currentSceneName == "MainGame") {
			sceneToLoad = "1_CutScene";
		} else if (currentSceneName == "SecondGame") {
			sceneToLoad = "2_CutScene";
		} else {
			int playerScore = PlayerPrefs.GetInt("score");
            Debug.Log("Current score is:" + playerScore + " so we're loading the next scene...");
            if (playerScore > MIN_SCORE_FOR_GOOD) {
				sceneToLoad = "Good_Cutscene";
			} else if (playerScore > MIN_SCORE_FOR_NORMAL) {
 				sceneToLoad = "Normal_Cutscene";
			} else {
				sceneToLoad = "Bad_Cutscene";
			}
		}
		Debug.Log ("Loading the next scene: "+sceneToLoad);
		StartCoroutine(ChangeScene(sceneToLoad));
	}

	IEnumerator ChangeScene (string sceneToLoad) {
		Debug.Log("Initiated the IEnumerator");
		fadeTime = fadingClass.BeginFade(1);		
		Debug.Log("Waiting for:" + fadeTime + "Seconds");
		yield return new WaitForSeconds (fadeTime);
		Debug.Log("Done waiting!");
		SceneManager.LoadScene (sceneToLoad, LoadSceneMode.Single);
	}
}
