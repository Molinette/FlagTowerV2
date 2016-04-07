using UnityEngine;
using System.Collections;

public class Enemy : EnemyBehaviour {

	public float damage; 
	public float health;
	public string name;
	public Animator animation;

	public override void Start(){
		base.Start();
	}

	public virtual void Damage () {
		
	}
}
