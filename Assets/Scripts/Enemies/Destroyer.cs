using UnityEngine;
using System.Collections;

public class Destroyer : Enemy {
	
	public float attackDelay;
	public Animator animator;
	private float nextAttackTime = 0;
	private GameObject tower;
	private bool isTowerDown  = false;
	private GameObject character;
	private bool attackState = false;
	private GameObject spawnManager;

	public override void Start(){
		base.Start();
		tower = GameObject.FindGameObjectWithTag("Tower");
		character = GameObject.FindGameObjectWithTag("Character");
		target = tower.transform;
		spawnManager = GameObject.Find("SpawnManager");
		spawnManager.GetComponent<EnemiesCounter> ().IncDestroyer();
	}

	public void Update(){
		if (rb.velocity.x < 0) {
			transform.localScale = new Vector3 (-1, transform.localScale.y, transform.localScale.z);
		}
		if(attackState){
			{
				if(Time.time >= nextAttackTime){
					Damage();
					nextAttackTime = Time.time + attackDelay;
				}
			}
		}

		//Looks if the tower is down
		if (tower.GetComponent<TowerDownScript>().getCurrentStep() <= 0){
			isTowerDown = true;
			target = character.transform;
			movingState = MovingStates.FollowTarget;
			attackState = false;
		}
	}

	public void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("TowerAttackingZone") && !isTowerDown){
			movingState = MovingStates.Idle;
			attackState = true;
			nextAttackTime = Time.time + attackDelay;
			animator.SetBool ("isAttacking", attackState);
		}

		if(other.CompareTag("Character")
			&& isTowerDown){
			float directionX = (other.transform.position.x - transform.position.x) / Mathf.Abs (other.transform.position.x - transform.position.x);
			other.transform.parent.GetComponent<PlayerController> ().Push(new Vector2(directionX,1));
		}
	}

	public void OnTriggerExit2D(Collider2D other){
		if(other.CompareTag("TowerAttackingZone")){
			movingState = MovingStates.FollowTarget;
			attackState = false;
			animator.SetBool ("isAttacking", attackState);
		}
	}

	void OnCollisionEnter2D(Collision2D collision){
		if(!collision.collider.gameObject.CompareTag("Ground")){



		}
	}

	public override void Damage () {
		tower.GetComponent<TowerDownScript>().changeHealth(-damage);
	}
}
