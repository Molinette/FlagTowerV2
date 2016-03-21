using UnityEngine;
using System.Collections;

public class Grenade : Explosive, Projectile, MonoBehaviour {

	public float getDamage(){

		return damage;
	}
}
