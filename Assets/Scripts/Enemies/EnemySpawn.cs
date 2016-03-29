using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour {


	public Transform [] differentSpawnPoints;
	public GameObject [] enemies;

	public float SpawnTime;

	// Use this for initialization
	void Start () {
		
		StartCoroutine (Spawn());
	}

	IEnumerator Spawn() {
		while(true) {
			Transform location = getRandomSpawnPoint ();
			Instantiate (enemies[0], location.position, Quaternion.identity);
			yield return new WaitForSeconds (SpawnTime);
		}
	}

	Transform getRandomSpawnPoint() {
		return differentSpawnPoints[Random.Range (0, differentSpawnPoints.Length)];
	}
}
