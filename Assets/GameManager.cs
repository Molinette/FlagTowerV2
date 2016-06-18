using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public float shopTime = 10;
	private float timeLeft;
	private float nextTime;

	private bool isDuringWave = true;
	private int waveCount = 1;
	private int enemiesLeft;
	public int enemiesWave = 5;
	public EnemySpawn enemySpawn;
	public PlayerInventory playerInventory;
	public Text enemiesText;
	public Text waveText;
	public Text timerText;
	public Button shopButton;
	public GameObject shopMenu;
	public GameObject flag;
	public GameObject tower;
	public GameObject character;

	// Use this for initialization
	void Start () {
		StartWave();
		shopButton.interactable = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time >= nextTime && !isDuringWave){
			StartWave();
		}
		if(isDuringWave == false){
			timeLeft = Mathf.Max(0,timeLeft - 1*Time.deltaTime);
			refreshTimerText();
		}

	}

	public void AddWave(){
		waveCount++;
	}

	public int GetWaveCount(){
		return waveCount;
	}

	public void SetIsDuringWave(bool isDuringWave){
		this.isDuringWave = isDuringWave;
	}

	public bool GetIsDuringWave(){
		return isDuringWave;
	}

	public int GetEnemiesLeft(){
		return enemiesLeft;
	}

	public int GetEnemiesWave(){
		return enemiesWave;
	}

	public void EndWave(){
		waveCount++;
		refreshWaveText();
		enemiesWave += enemiesWave;
		isDuringWave = false;
		nextTime = Time.time + shopTime;
		playerInventory.AddWaveMoney();
		shopButton.interactable = true;
		timerText.gameObject.SetActive(true);
		waveText.gameObject.SetActive(false);
		timeLeft = shopTime;
		refreshTimerText();
		character.transform.parent = tower.transform;
		flag.transform.parent = tower.transform;
	}

	public void StartWave(){
		enemiesLeft = enemiesWave;
		refreshEnemiesText();
		isDuringWave = true;
		enemySpawn.StartNewWave(enemiesWave);
		shopButton.interactable = false;
		timerText.gameObject.SetActive(false);
		waveText.gameObject.SetActive(true);
		shopMenu.SetActive(false);
		character.transform.parent = null;
		flag.transform.parent = null;
	}

	public void RemoveEnemy(){
		enemiesLeft--;
		refreshEnemiesText();
		if(enemiesLeft <= 0){
			EndWave();
		}
	}

	public void AddEnemy(){
		enemiesLeft++;
		refreshEnemiesText();
	}

	private void refreshEnemiesText()
	{
		enemiesText.text = "" + enemiesLeft;
	}

	private void refreshWaveText()
	{
		waveText.text = "Wave " + waveCount;
	}

	private void refreshTimerText()
	{
		timerText.text = "Next wave \n " + Mathf.Floor(timeLeft);
	}
}
