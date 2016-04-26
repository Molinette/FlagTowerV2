using UnityEngine;
using System.Collections;
[RequireComponent (typeof (Rigidbody2D))]

public class PlayerController : MonoBehaviour {

	//Character movement
	public float maxRunningVelocity = 8f;
	public float runningAcceleration = 40f;
	public float breakingAcceleration = 16f;
	public float jumpingForce = 8f;

	//Animation
	public GameObject body;
	public Animator anim;

	//If the character is touching the ground
	private bool isGrounded = false;
	private LayerMask groundLayer;
	private float groundCheckRadius = 0.25f;
	private Vector2 feetLocalPosition = new Vector2(0,-1);

	//The character's rigid body
	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D>();
		groundLayer = LayerMask.NameToLayer("Ground");
	}

	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate(){

		float horizontalInput = Input.GetAxis("Horizontal");
		float jumpInput = Input.GetAxis("Jump");

		anim.SetFloat("speed",Mathf.Abs(horizontalInput));

		//New x velocity
		float velocityX;

		//Looks if the character is grounded
		isGrounded = Physics2D.OverlapCircle(transform.TransformPoint(feetLocalPosition),
			groundCheckRadius, 1 << groundLayer);

		//Jump mechanic
		if(jumpInput > 0 && isGrounded && rb.velocity.y == 0){
			rb.AddForce(Vector2.up * jumpingForce,ForceMode2D.Impulse);
		}

		//Moving mechanic
		/*Adds acceleration to the current velocity and affect it to the rigidbody
		depending on the direction*/
		if(horizontalInput > 0){
			body.GetComponent<SpriteRenderer>().flipX = true;
			velocityX = rb.velocity.x + runningAcceleration*Time.deltaTime*horizontalInput;
			rb.velocity = new Vector2(Mathf.Min(velocityX,maxRunningVelocity),rb.velocity.y);
		}
		else if(horizontalInput < 0){
			body.GetComponent<SpriteRenderer>().flipX = false;
			velocityX = rb.velocity.x + runningAcceleration*Time.deltaTime*horizontalInput;
			rb.velocity = new Vector2(Mathf.Max(velocityX,-maxRunningVelocity),rb.velocity.y);
		}
		else{
			if(isGrounded){
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

	}

	void OnCollisionStay2D(Collision2D collision){
		if(collision.collider.gameObject.transform.parent != null){
			if(collision.collider.gameObject.transform.parent.CompareTag("Platform")){
				if(Input.GetAxis("Vertical") < 0){
					Component[] colliders = GetComponentsInChildren<Collider2D>();
					foreach(Collider2D collider in colliders){
						Physics2D.IgnoreCollision(collider, collision.collider, true);
					}
				}
			}
		}
	}
}
