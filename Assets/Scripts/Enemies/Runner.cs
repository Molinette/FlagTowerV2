using UnityEngine;
using System.Collections;

public class Runner : Enemy {

	//If the monster is touching the ground
	private bool isGrounded = false;
	private LayerMask groundLayer;
	private LayerMask platformLayer;
	private float groundCheckRadius = 0.25f;
	private Vector2 feetLocalPosition = new Vector2(0,-1);

	private GameObject mainFlag;

	//If the flag is in its hand
	private bool hasFlag = false;
	//Where the flag will be held
	public Transform flagHoldingPos;

	private GameObject spawnManager;

	// Use this for initialization
	public override void Start () {
		base.Start();
		target = GameObject.FindGameObjectWithTag("Flag").transform;
		platformLayer = LayerMask.NameToLayer("Platform");
		mainFlag = GameObject.FindGameObjectWithTag ("Flag");
		spawnManager = GameObject.Find("SpawnManager");
		spawnManager.GetComponent<EnemiesCounter> ().IncRunner();
	}

	// Update is called once per frame
	public override void FixedUpdate () {
		isGrounded = Physics2D.OverlapCircle(transform.TransformPoint(feetLocalPosition),groundCheckRadius, 1 << platformLayer);

		int direction;

		switch(movingState){
		case MovingStates.Left :
			Move(-1);
			break;

		case MovingStates.Right :
			Move(1);
			break;

		case MovingStates.Jump :
			Jump();
			break;
		case MovingStates.Idle :
			Move(0);
			break;
		case MovingStates.FollowTarget :
			direction = getTargetDirection(target.position);
			Move(direction);
			break;
		case MovingStates.StealTarget :
			direction = getTargetDirection(getClosestWinZone());
			Move(direction);
			break;
		}

	}

	void Jump() {
		if(isGrounded && rb.velocity.y == 0){
			rb.AddForce(Vector2.up * jumpingForce,ForceMode2D.Impulse);
		}
	}

	Vector3 getClosestWinZone(){
		Transform target;
		GameObject[] winZones = GameObject.FindGameObjectsWithTag("WinZone");
		if (Mathf.Abs(winZones[0].transform.position.x - transform.position.x) < Mathf.Abs(winZones[1].transform.position.x - transform.position.x)){
			target = winZones[0].transform;
		}
		else{
			target = winZones[1].transform;
		}
		return target.position;
	}

	void OnTriggerStay2D(Collider2D other){
		if(other.gameObject.CompareTag("PathNode")){
			Jump();
		}
	}

	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.CompareTag ("Flag")) {
			collider.transform.parent.transform.parent = gameObject.transform;
			collider.transform.parent.position = flagHoldingPos.transform.position;
			collider.transform.parent.GetComponent<Rigidbody2D>().isKinematic = true;
			//Ligne ajouté le 5/10/2016 par Julien pour dire que le flag est taken
			mainFlag.GetComponent<FlagReset>().SetTaken(true);
			hasFlag = true;
			movingState = MovingStates.StealTarget;
		}
	}

	public override void ReceiveDamage (float damage) {
		curr_health -= damage;
		if (curr_health <= 0) {
			if (hasFlag) {
				DropFlag ();
			}
			Destroy (this.gameObject);
		} else {
			SetHealthBar (this.curr_health / this.max_health);
		}
	}

	void DropFlag() {
		GameObject flag = GameObject.FindGameObjectWithTag ("Flag");
		flag.transform.parent = null;
		flag.GetComponent<Rigidbody2D> ().isKinematic = false;
		//Ligne ajouté le 5/10/2016 par Julien pour dire que le flag n'est plus en possession du runner
		mainFlag.GetComponent<FlagReset>().SetTaken(false);
	}
}
