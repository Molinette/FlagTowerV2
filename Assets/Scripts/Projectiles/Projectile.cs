using UnityEngine;
using System.Collections;

public abstract class Projectile : IProjectile, MonoBehaviour {

	public float damage;
	public float initialSpeed;
}
