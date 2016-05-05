using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class FlagOut : MonoBehaviour {

	public Text gameOverText;
	public float pauseDuration;
	private bool hasAppeared;

	void Start(){

		gameOverText.text = "";
		hasAppeared = false;
	}

	void Update(){

		if (gameObject.GetComponent<Renderer> ().isVisible) {
			hasAppeared = true;
		}
		if (hasAppeared) {
			if (!gameObject.GetComponent<Renderer> ().isVisible){
				gameOverText.text = "GameOver!";
				StartCoroutine (Pause (pauseDuration));
				Time.timeScale = 0f;
			}
		}
	}

	private IEnumerator Pause(float p)
	{
		float pauseEndTime = Time.realtimeSinceStartup + p;
		while (Time.realtimeSinceStartup < pauseEndTime)
		{
			yield return null;
		}
		ResetGame();
	}

	void ResetGame()
	{
		//Déroulement du temps normal
		Time.timeScale = 1;
		SceneManager.LoadScene(0);
	}
}
