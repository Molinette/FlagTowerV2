using UnityEngine;
using System.Collections;

public class Destroyer : Enemy {
	
	public float attackDelay;
	private float nextAttackTime = 0;
	private GameObject tower;
	private bool attackState = false;
	private GameObject spawnManager;

	public override void Start(){
		base.Start();
		tower = GameObject.FindGameObjectWithTag("Tower");
		target = tower.transform;
		spawnManager = GameObject.Find("SpawnManager");
		spawnManager.GetComponent<EnemiesCounter> ().IncDestroyer();
	}

	public void Update(){
		if(attackState){
			{
				if(Time.time >= nextAttackTime){
					Damage();
					nextAttackTime = Time.time + attackDelay;
				}
			}
		}
	}

	public void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("TowerAttackingZone")){
			movingState = MovingStates.Idle;
			attackState = true;
		}
	}

	public void OnTriggerExit2D(Collider2D other){
		if(other.CompareTag("TowerAttackingZone")){
			movingState = MovingStates.FollowTarget;
			attackState = false;
		}
	}

	void OnCollisionEnter2D(Collision2D collision){
		if(!collision.collider.gameObject.CompareTag("Ground")){

			if(collision.collider.gameObject.CompareTag("Character")
				&& tower.GetComponent<TowerDownScript>().getCurrentStep() == 0){
				float directionX = (collision.collider.gameObject.transform.position.x - transform.position.x) / Mathf.Abs (collision.collider.gameObject.transform.position.x - transform.position.x);
				collision.collider.gameObject.transform.parent.GetComponent<PlayerController> ().Push(new Vector2(directionX,1));
			}


		}
	}

	public override void Damage () {
		tower.GetComponent<TowerDownScript>().changeHealth(-damage);
	}
}
