using UnityEngine;
using System.Collections;

public class AirStriker : Enemy {
	
	public GameObject [] ObjectsToDrop;
	public Transform [] Targets;
	public int GameObjectToSpawn;

	private float SpawnTime = 3f;
	private int targetDirection = GetTargetDirection;

	void Start () {
		StartCoroutine (Drop());
	}

	void Update () {
		base.target = Targets [targetDirection];
		if (targetDirection == 1) {
			Move (1);
		} else {
			Move (-1);
		}
	}

	IEnumerator Drop () {
		while (true) {
			Instantiate (ObjectsToDrop[GameObjectToSpawn], transform.FindChild ("DropAnchor").position, Quaternion.identity);
			yield return new WaitForSeconds (SpawnTime);
		}
	}

	private int GetTargetDirection () {
		float x = transform.position.x;
		if (x < 0) { //The airstrike spawned on the left.
			return 1;
		}
		return 0; //The airstrike spawned on the right.
	}
			
}
