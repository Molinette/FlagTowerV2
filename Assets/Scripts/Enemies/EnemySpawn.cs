using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour {

	public Transform [] groundSpawnPoint;
	public Transform [] airSpawnPoint;
	public GameObject [] enemies;
	public float SpawnTime;
	public float spawnTimeDecrease = 1;
	private Transform location;
	private GameObject chosenEnemie;
	private int enemiesWave = 0;
	private int enemiesSpawned = 1;

	void Start () {
		StartCoroutine (Spawn());
	}

	IEnumerator Spawn() {
		while(true) {
			spawnSetup ();
			yield return new WaitForSeconds (SpawnTime);
		}
	}

    void spawnSetup()
    {
		if(enemiesSpawned < enemiesWave){
			int randomNb = Random.Range(0, 20);
			if(randomNb <= 10){
				chosenEnemie = enemies [1];
				location = getRandomGroundPoint();
			}
			else if(randomNb > 10 && randomNb <= 15){
				chosenEnemie = enemies [2];
				location = getRandomGroundPoint();
			}
			else if(randomNb > 15 && randomNb <= 17){
				chosenEnemie = enemies [3];
				location = getRandomGroundPoint();
			}
			else{
				chosenEnemie = enemies [0];
				location = getRandomAirPoint();
			}
			Instantiate (chosenEnemie, location.position, Quaternion.identity);
			enemiesSpawned++;
		}
    }

	Transform getRandomGroundPoint() {
		return groundSpawnPoint[Random.Range (0, groundSpawnPoint.Length)];
	}

	Transform getRandomAirPoint() {
		return airSpawnPoint[Random.Range (0, airSpawnPoint.Length)];
	}

	public void StartNewWave(int enemiesWave){
		enemiesSpawned = 0;
		this.enemiesWave = enemiesWave;
		SpawnTime = Mathf.Max(1,SpawnTime - spawnTimeDecrease);
	}
}
