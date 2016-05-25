using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour {

	public Transform [] groundSpawnPoint;
	public Transform [] airSpawnPoint;
	public GameObject [] enemies;
	public float SpawnTime;
	private Transform location;
	private GameObject chosenEnemie;
	private int value;

	void Start () {
		StartCoroutine (Spawn());
	}

	IEnumerator Spawn() {
		while(true) {
			spawnSetup ();
			Instantiate (chosenEnemie, location.position, Quaternion.identity);
			yield return new WaitForSeconds (SpawnTime);
		}
	}
		
    void spawnSetup()
    {
		value = Random.Range(0, enemies.Length);

		if (value == 0) {
			chosenEnemie = enemies [value];
			location = getRandomAirPoint();
		} 

		else {
			chosenEnemie = enemies [value];
			location = getRandomGroundPoint();
		}
    }

	Transform getRandomGroundPoint() {
		return groundSpawnPoint[Random.Range (0, groundSpawnPoint.Length)];
	}

	Transform getRandomAirPoint() {
		return airSpawnPoint[Random.Range (0, airSpawnPoint.Length)];
	}
}
