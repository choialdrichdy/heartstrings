using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fading : MonoBehaviour {

	public Texture2D fadeOutTexture;
	public float fadeSpeed = 2.0f;
	private int drawDepth = -1000;
	private float alpha = 1.0f;
	private int fadeDir = -1; // fade out is 1, fade out is -2

	void OnGUI () {
		alpha += fadeDir * fadeSpeed * Time.deltaTime;
		alpha = Mathf.Clamp01 (alpha);
		GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha);
		GUI.depth = drawDepth;
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), fadeOutTexture); 
		if (0.0f<alpha && alpha<1.0f) {
			Debug.Log ("GUI being drawn with alpha at " + alpha + " and time at " + Time.deltaTime);
		}
	}
	public float BeginFade (int direction) {
		Debug.Log ("BeginFade initiated with it being faded out " + direction);
		fadeDir = direction;
		return (fadeSpeed);
	}
	void OnLevelFinishedLoading(){
		BeginFade (-1);
	}
}
