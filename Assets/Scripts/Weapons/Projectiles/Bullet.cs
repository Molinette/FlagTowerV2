using UnityEngine;
using System.Collections;

public class Bullet : Projectile{


	// Update is called once per frame
	void Update()
	{
		Destroy(this.gameObject, 2);
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
