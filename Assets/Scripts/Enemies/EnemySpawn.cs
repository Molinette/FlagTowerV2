using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour {

	public Transform [] groundSpawnPoint;
	public Transform [] airSpawnPoint;
	public GameObject [] enemies;
	private Transform location;
	private GameObject chosenEnemie;
	private int value;


	public float SpawnTime;

	// Use this for initialization
	void Start () {
		StartCoroutine (Spawn());
	}

	IEnumerator Spawn() {
		while(true) {
			getEnemy ();
			Instantiate (chosenEnemie, location.position, Quaternion.identity);
			yield return new WaitForSeconds (SpawnTime);
		}
	}

	Transform getRandomGroundPoint() {
		return groundSpawnPoint[Random.Range (0, groundSpawnPoint.Length)];
	}

	Transform getRandomAirPoint() {
		return airSpawnPoint[Random.Range (0, airSpawnPoint.Length)];
	}

    int getEnemy()
    {
		value = Random.Range(0, enemies.Length);
		if (value == 4) {
			chosenEnemie = enemies [value];
			location = airSpawnPoint[getRandomAirPoint];
		} 

		else {
			chosenEnemie = enemies [value];
			location = groundSpawnPoint[getRandomGroundPoint];
		}
			
    }
}
