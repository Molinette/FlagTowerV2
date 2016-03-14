using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour {

	public GameObject enemy;
	public float SpawnTime;

	// Use this for initialization
	void Start () {
		StartCoroutine (Spawn());
	}

	IEnumerator Spawn() {
		while(true) {
			Instantiate (enemy, transform.position, Quaternion.identity);
			yield return new WaitForSeconds (SpawnTime);
		}
	}
}
