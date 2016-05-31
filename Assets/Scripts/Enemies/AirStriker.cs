using UnityEngine;
using System.Collections;

public class AirStriker : Enemy {
	
	public GameObject [] ObjectsToDrop;
	public Transform [] Targets;
	public int GameObjectToSpawn;

	private float SpawnTime = 3f;
	private int targetDirection;

	public override void Start () {
		base.Start ();
		targetDirection = GetTargetDirection();
		base.target = Targets [targetDirection];
		StartCoroutine (Drop());
	}

	public override void FixedUpdate () {
		int direction;

		switch (movingState) {
		case MovingStates.Idle:
			Move (0);
			break;
		case MovingStates.FollowTarget:
			direction = getTargetDirection (target.position);
			Move (direction);
			break;
		}

	}

	IEnumerator Drop () {
		while (true) {
			Instantiate (ObjectsToDrop[GetObjectToSpawn()], transform.FindChild ("DropAnchor").position, Quaternion.identity);
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

	public int GetObjectToSpawn(){
		if(Random.Range(0,11) < 2){
			return 1;
		}
		else{
			return 0;
		}
	}
			
}
