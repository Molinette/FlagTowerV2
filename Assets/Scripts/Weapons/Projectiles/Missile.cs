using UnityEngine;
using System.Collections;

public class Missile : Explosive {

	public float missileAcceleration;
	public float explosionForce;


	void OnCollisionEnter2D(Collision2D collision){

			Explode ();
			GameObject.Instantiate (explosionPrefab, transform.position, Quaternion.Euler (explosionPrefab.transform.eulerAngles));
			Destroy (gameObject);
	}


	void Explode(){
		Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position,explosionRadius);
		foreach(Collider2D collider in colliders){
			Rigidbody2D colliderRb = collider.gameObject.GetComponent<Rigidbody2D>();
			if(colliderRb != null){
				Vector2 direction = collider.transform.position - transform.position;
				colliderRb.AddForce(direction.normalized*explosionForce,ForceMode2D.Impulse);
			}
		}
	}
}
