using UnityEngine;
using System.Collections;

public class Enemy : EnemyBehaviour, IDamage {

	public float damage; 
	public float health;
	public string name;
	//Target to follow
	public Transform target;
	public Animator animation;

	public void Damage (float dmg) {

	}
}
