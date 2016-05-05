using UnityEngine;
using System.Collections;

public abstract class Projectile : MonoBehaviour {

	protected float damage;

	public void SetDamage(float damage){

		this.damage = damage;
	}

	public float GetDamage(){
	
		return damage;
	}


}
