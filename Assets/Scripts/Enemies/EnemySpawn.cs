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
			Instantiate (enemies[getEnemy()], location.position, Quaternion.identity);
			yield return new WaitForSeconds (SpawnTime);
		}
	}

	Transform getRandomSpawnPoint() {
		return differentSpawnPoints[Random.Range (0, differentSpawnPoints.Length)];
	}

	int getEnemy(){
		if(Random.Range(0,9) >= 2){
			return 0;
		}
		else
		{
			if(Random.Range(0,9) >= 5){
				return 1;
			}
			else
			{
				return 2;
			}
		}
	}
}
