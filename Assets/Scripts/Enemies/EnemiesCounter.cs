using UnityEngine;
using System.Collections;

public class EnemiesCounter : MonoBehaviour {


	private int numRunner;
	private int numDestroyer;
	private int numBomber;
	private int numAirstriker;
	private int totalEnemies;

	void Start () {
		numRunner = 0;
		numDestroyer = 0;
		numBomber = 0;
		numAirstriker = 0;
		totalEnemies = 0;
	}
	
	// Update is called once per frame
	void Update () {

		totalEnemies = numRunner + numDestroyer + numBomber + numAirstriker;
		print(numRunner);
	}

	public int GetRunner(){
	
		return numRunner;
	}

	public void IncRunner(){
		numRunner = numRunner + 1;
	}

	public void DecRunner(){
	
		numRunner = numRunner - 1;
	}

	public void SetRunner(int run){
	
		numRunner = run;
	}

		
	public int GetDestroyer(){

		return numDestroyer;
	}

	public void IncDestroyer(){

		numDestroyer = numDestroyer + 1;
	}

	public void DecDestroyer(){

		numDestroyer = numDestroyer - 1;
	}

	public void SetDestroyer(int dest){

		numDestroyer = dest;
	}


	public int GetBomber(){

		return numBomber;
	}

	public void IncBomber(){

		numBomber = numBomber + 1;
	}

	public void DecBomber(){

		numBomber = numBomber - 1;
	}
		
	public void SetBomber(int bomb){

		numBomber = bomb;
	}


	public int GetAirstriker(){

		return numAirstriker;
	}

	public void IncAirstriker(){

		numAirstriker = numAirstriker + 1;
	}

	public void DecAirstriker(){

		numAirstriker = numAirstriker - 1;
	}

	public void SetAirstriker(int air){

		numAirstriker = air;
	}


	public int GetTotalEnemies(){

		return totalEnemies;
	}
}
