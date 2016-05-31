using UnityEngine;
using System.Collections;

public class Bullet : Projectile{

	private bool hasAppeared;

	void Start(){

		hasAppeared = false;
	}

	void Update(){
	
		if (gameObject.GetComponent<Renderer> ().isVisible) {
			hasAppeared = true;
		}
		if (hasAppeared) {
			if (!gameObject.GetComponent<Renderer> ().isVisible){
				Destroy (gameObject);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.CompareTag("Hitbox")){
			Enemy currentEnemy = other.transform.parent.GetComponent<Enemy> ();
			if (currentEnemy) {
				currentEnemy.ReceiveDamage (damage);
			}
		}
		Destroy (gameObject);
	}

	void OnCollisionEnter2D(Collision2D collision){
		Destroy(gameObject);
	}
}
