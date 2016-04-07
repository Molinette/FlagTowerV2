using UnityEngine;
using System.Collections;

public class Destroyer : Enemy {
	public float attackDelay;
	private float nextAttackTime = 0;
	private GameObject tower;
	private bool attackState = false;

	public override void Start(){
		base.Start();
		tower = GameObject.FindGameObjectWithTag("Tower");
		target = tower.transform;
	}

	public void Update(){
		if(attackState){
			{
				if(Time.time >= nextAttackTime){
					Damage();
					print(" gutchy");
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

	public override void Damage () {
		tower.GetComponent<TowerDownScript>().changeHealth(-damage);
	}
}
