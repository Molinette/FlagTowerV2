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

	//The monster's rigibody
	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D>();
		groundLayer = LayerMask.NameToLayer("Ground");
		target = GameObject.FindGameObjectWithTag("Flag").transform;
	}

	// Update is called once per frame
	void FixedUpdate () {
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
		case MovingStates.FetchFlag :
			direction = getTargetDirection(target.position);
			Move(direction);
			break;
		case MovingStates.StealFlag :
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

	void Move(int direction) {
		//New x velocity
		float velocityX;

		/*Adds acceleration to the current velocity and affect it to the rigidbody
		depending on the direction*/
		if(direction > 0){
			velocityX = rb.velocity.x + runningAcceleration*Time.deltaTime;
			rb.velocity = new Vector2(Mathf.Min(velocityX,maxRunningVelocity),rb.velocity.y);
		}

		else if(direction < 0){
			velocityX = rb.velocity.x - runningAcceleration*Time.deltaTime;
			rb.velocity = new Vector2(Mathf.Max(velocityX,-maxRunningVelocity),rb.velocity.y);
		}

		else
		{
			if(rb.velocity.x > 0){
				velocityX = rb.velocity.x - breakingAcceleration*Time.deltaTime;
				rb.velocity = new Vector2(Mathf.Max(velocityX,0),rb.velocity.y);
			}
			else if(rb.velocity.x < 0){
				velocityX = rb.velocity.x + breakingAcceleration*Time.deltaTime;
				rb.velocity = new Vector2(Mathf.Min(velocityX,0),rb.velocity.y);
			}
		}
	}

	int getTargetDirection(Vector3 targetPos){
		int direction;
		float posDifference = targetPos.x - transform.position.x;
		direction = (int)(posDifference/Mathf.Abs(posDifference));
		return direction;
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
		if (collider.gameObject.CompareTag ("Flag")) {
			Debug.Log ("True found flag");
			collider.transform.parent = gameObject.transform;
			collider.transform.position = flagHoldingPos.transform.position;
			collider.GetComponent<Rigidbody2D>().isKinematic = true;
			collider.enabled = false;
			hasFlag = true;
			movingState = MovingStates.StealFlag;
		}
	}
}
