using UnityEngine;
using System.Collections;

public class AirStriker : Enemy {
	
	public GameObject [] ObjectsToDrop;
	public Transform [] Targets;
	public int GameObjectToSpawn;

	public float SpawnTime = 3f;
	private int targetDirection;

	private bool hasAppeared;

	public override void Start () {
		base.Start ();
		hasAppeared = false;
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

	public void Update(){
		if (transform.Find("BodySprite").GetComponent<Renderer>().isVisible) {
			hasAppeared = true;
		}
		if (hasAppeared) {
			if (!transform.Find("BodySprite").GetComponent<Renderer>().isVisible){
				gameManager.RemoveEnemy();
				Destroy (gameObject);
			}
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
		if(Random.Range(0,11) < 3){
			gameManager.AddEnemy();
			return 1;
		}
		else{
			return 0;
		}
	}
			
}
