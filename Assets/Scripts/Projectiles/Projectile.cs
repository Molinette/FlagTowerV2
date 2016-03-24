using UnityEngine;
using System.Collections;

public abstract class Projectile : MonoBehaviour {

	public float damage;
	public float initialSpeed;

	public float getDamage(){
	
		return damage;
	}
}
