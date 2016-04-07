using UnityEngine;
using System.Collections;

public class Runner : Enemy {

	//If the monster is touching the ground
	private bool isGrounded = false;
	private LayerMask groundLayer;
	private float groundCheckRadius = 0.25f;
	private Vector2 feetLocalPosition = new Vector2(0,-1);

	//If the flag is in its hand
	private bool hasFlag = false;
	//Where the flag will be held
	public Transform flagHoldingPos;

	// Use this for initialization
	public override void Start () {
		base.Start();
		target = GameObject.FindGameObjectWithTag("Flag").transform;
		groundLayer = LayerMask.NameToLayer("Ground");
	}

	// Update is called once per frame
	public override void FixedUpdate () {
		isGrounded = Physics2D.OverlapCircle(transform.TransformPoint(feetLocalPosition),groundCheckRadius, 1 << groundLayer);
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
			hasFlag = true;
			movingState = MovingStates.FollowTarget;
		}
	}
}
