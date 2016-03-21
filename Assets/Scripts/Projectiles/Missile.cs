using UnityEngine;
using System.Collections;

public class Missile : Explosive, Projectile, MonoBehaviour {

	public float missileAcceleration;

	public float getDamage(){
	
		return damage;
	}
}
