using UnityEngine;
using System.Collections;

public class FlagReset : MonoBehaviour {

	private Vector3 startingPosition;
	private Vector3 currentPosition;
	private bool isTaken;
	private bool idle;
	private bool atSpawn;
	//Respawn Timer = spawnTimer + idleTimer
	public float spawnTimer = 3f;
	private float idleTimer = 2f;
	private float resetIdleTimer;
	private float resetSpawnTimer;
	private PlayerInventory playerInventory ;

	void Start () {

		isTaken = false;
		atSpawn = true;
		startingPosition = gameObject.transform.position;
		resetIdleTimer = idleTimer;
		resetSpawnTimer = spawnTimer;
		playerInventory = GameObject.Find("Character").GetComponent<PlayerInventory>();

	}

	void Update () {

		ResetFlag ();
		IsItIdle ();
		if(isTaken) {
			
			playerInventory.Penalize ();

		}
	}

	public void SetTaken(bool isTaken){

		this.isTaken = isTaken;
		atSpawn = false;
	}

	public bool GetTaken(){
	
		return isTaken;
	}

	public void IsItIdle(){

		idleTimer -= Time.deltaTime;
		currentPosition = gameObject.transform.position;
		if (idleTimer < 0) {
			if (currentPosition == gameObject.transform.position) {
				idle = true;
				idleTimer = resetIdleTimer;
			}
			else
				idle = false;
		} 
	}

	public void ResetFlag(){

		if (!GetTaken() && idle && !atSpawn) {
			spawnTimer -= Time.deltaTime;

			if (spawnTimer <= 0) {
				gameObject.transform.position = startingPosition;
				atSpawn = true;
				spawnTimer = resetSpawnTimer;
			}
		}
	}
}
