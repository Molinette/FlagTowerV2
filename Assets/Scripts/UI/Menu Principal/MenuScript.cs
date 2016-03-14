using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {


	public GameObject quitMenu;
	public Button startText;
	public Button exitText;
	public Text highscore;
	public int score = 0;
	public int highScore = 0;
	string highScoreKey = "HighScore";


	// Use this for initialization
	void Start () {

		startText = startText.GetComponent<Button> ();
		exitText = exitText.GetComponent<Button> ();
		highScore = PlayerPrefs.GetInt(highScoreKey,0);
		quitMenu.SetActive(false);
	}
	 

	void Update(){
		
		highscore.text = "highScore: " + score.ToString();
	}


	void OnDisable(){

		if (score > highScore) {
			PlayerPrefs.SetInt(highScoreKey, score);
			PlayerPrefs.Save();
		}
	}


	public void exitPress(){

		quitMenu.SetActive(true);
		startText.enabled = false;
		exitText.enabled = false;
	}
		

	public void noPress(){

		quitMenu.SetActive(false);
		startText.enabled = true;
		exitText.enabled = true;
	}


	public void startLevel(){
	
		SceneManager.LoadScene(1);
	}


	public void exitGame(){
		Application.Quit ();
		UnityEditor.EditorApplication.isPlaying = false;
	}

}
