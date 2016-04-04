using UnityEngine;
using System.Collections;

public class Enemy : EnemyBehaviour, IDamage {

	public float damage; 
	public float max_health;
	public float curr_health;
	public string name;
	public GameObject health_bar;
	//Target to follow
	public Transform target;
	public Animator animation;

	public virtual void Damage (float dmg) {

	}
}
