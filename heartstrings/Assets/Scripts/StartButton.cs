using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class StartButton : MonoBehaviour {
	public AudioSource startSound;

	void start() {
		
		startSound = GetComponent<AudioSource> ();
        PlayerPrefs.SetInt("score",0);
	}

	public void LoadScene() {
		StartCoroutine(WaitABit());
	}

	IEnumerator WaitABit() {
		Debug.Log(Time.timeSinceLevelLoad);
        startSound.Play();
		yield return new WaitForSeconds(1);
		SceneManager.LoadScene ("Scenes/0_CutScene");
		Debug.Log(Time.timeSinceLevelLoad);
	}
}
