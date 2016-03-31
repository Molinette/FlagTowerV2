using UnityEngine;
using System.Collections;

public abstract class Projectile : MonoBehaviour {

	public float damage;

	public void setDamage(float damage){

		this.damage = damage;
	}

	public float getDamage(){
	
		return damage;
	}
}
