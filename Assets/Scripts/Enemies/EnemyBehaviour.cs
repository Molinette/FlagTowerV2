using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour
{
	//Moving states
	public enum MovingStates{Idle, FollowTarget, Left, Right, Jump, StealTarget, Attack};
	public MovingStates movingState;

	//Enemy movement
	public float maxRunningVelocity = 5f;
	public float runningAcceleration = 40f;
	public float breakingAcceleration = 16f;
	public float jumpingForce = 8f;

	//The monster's rigibody
	protected Rigidbody2D rb;

	//Target to follow
	public Transform target;

	// Use this for initialization
	public virtual void Start () {
		rb = gameObject.GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	public virtual void FixedUpdate () {
		int direction;

		switch(movingState){
		case MovingStates.Left :
			Move(-1);
			break;

		case MovingStates.Right :
			Move(1);
			break;

		case MovingStates.Idle :
			Move(0);
			break;

		case MovingStates.FollowTarget :
			direction = getTargetDirection(target.position);
			Move(direction);
			break;
		}
			
	}

	public void Move(int direction) {
		//New x velocity
		float velocityX;

		/*Adds acceleration to the current velocity and affect it to the rigidbody
		depending on the direction*/
		if(direction > 0){
			if (rb == null) {
				print ("is null");
			}
			velocityX = rb.velocity.x + runningAcceleration*Time.deltaTime;
			rb.velocity = new Vector2(Mathf.Min(velocityX,maxRunningVelocity),rb.velocity.y);
		}

		else if(direction < 0){
			if (rb == null) {
				print ("is null");
			}
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

	public int getTargetDirection(Vector3 targetPos){
		int direction;
		float posDifference = targetPos.x - transform.position.x;
		direction = (int)(posDifference/Mathf.Abs(posDifference));
		return direction;
	}
}

