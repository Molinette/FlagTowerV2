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

	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.CompareTag("Enemy")){
			Enemy currentEnemy = collision.gameObject.GetComponent<Enemy> ();
			if (currentEnemy) {
				currentEnemy.ReceiveDamage (damage);
			}
		}
		Destroy (gameObject);
	}
}
