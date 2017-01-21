using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class StartButton : MonoBehaviour {
	public RectTransform startText;
	public AudioSource startSound;

	void start() {
		startText = GetComponent<RectTransform> ();
		startSound = GetComponent<AudioSource> ();
	}

	public void LoadScene() {
		Debug.Log ("You have clicked the button!");
		StartCoroutine(WaitABit());
	}

	IEnumerator WaitABit() {
		Debug.Log(Time.time);
		yield return new WaitForSeconds(1);
		SceneManager.LoadScene ("Scenes/Main_Scene");
		Debug.Log(Time.time);
	}
}
