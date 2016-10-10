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
	string highScoreKey = "High Score";
   


    // Use this for initialization
    void Start () {

		startText = startText.GetComponent<Button> ();
		exitText = exitText.GetComponent<Button> ();
		if (!PlayerPrefs.HasKey(highScoreKey)) {
			PlayerPrefs.SetInt(highScoreKey, 0);
		}
		score = PlayerPrefs.GetInt(highScoreKey);
		quitMenu.SetActive(false);
    }

	void Update(){
		if (Input.GetKeyDown (KeyCode.R)) {
			PlayerPrefs.SetInt(highScoreKey, 0);
			score = PlayerPrefs.GetInt(highScoreKey);
		}
		highscore.text = "Highest wave : " + score.ToString();
	}


	void OnDisable(){

		/*if (score > highScore) {
			PlayerPrefs.SetInt(highScoreKey, score);
			PlayerPrefs.Save();
		}*/
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
