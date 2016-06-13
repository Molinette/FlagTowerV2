using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public float shopTime = 10;
	private float nextTime;

	private bool isDuringWave = true;
	private int waveCount = 1;
	private int enemiesLeft;
	private int enemiesWave = 5;
	public EnemySpawn enemySpawn;
	public PlayerInventory playerInventory;
	public Text enemiesText;
	public Text waveText;
	public Button shopButton;

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
		enemiesWave += 5;
		isDuringWave = false;
		nextTime = Time.time + shopTime;
		playerInventory.AddWaveMoney();
		shopButton.interactable = true;
	}

	public void StartWave(){
		enemiesLeft = enemiesWave;
		refreshEnemiesText();
		isDuringWave = true;
		enemySpawn.StartNewWave(enemiesWave);
		shopButton.interactable = false;
	}

	public void RemoveEnemy(){
		enemiesLeft--;
		refreshEnemiesText();
		if(enemiesLeft <= 0){
			EndWave();
		}
	}

	private void refreshEnemiesText()
	{
		enemiesText.text = "Enemies left: " + enemiesLeft;
	}

	private void refreshWaveText()
	{
		waveText.text = "Wave " + waveCount;
	}
}
