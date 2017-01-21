using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class StartButton : MonoBehaviour {
	public AudioSource startSound;

	void start() {
		
		startSound = GetComponent<AudioSource> ();
	}

	public void LoadScene() {
		Debug.Log ("You have clicked the button!");
		StartCoroutine(WaitABit());
	}

	IEnumerator WaitABit() {
		Debug.Log(Time.time);
        startSound.Play();
		yield return new WaitForSeconds(1);
		SceneManager.LoadScene ("Scenes/MainGame");
		Debug.Log(Time.time);
	}
}
