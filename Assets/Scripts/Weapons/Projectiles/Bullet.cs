using UnityEngine;
using System.Collections;

public class Bullet : Projectile{



	// Update is called once per frame
	void Update()
	{
		Destroy(this.gameObject, 2);
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Enemy")
		{
			Destroy(gameObject);
		}
	}
}
