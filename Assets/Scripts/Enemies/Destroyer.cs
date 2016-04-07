using UnityEngine;
using System.Collections;

public class Destroyer : Enemy {
	private GameObject tower;
	public override void Start(){
		base.Start();
		tower = GameObject.FindGameObjectWithTag("Tower");
		target = tower.transform;
	}

	public void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("TowerAttackingZone")){
			movingState = MovingStates.Idle;
		}
	}
}
