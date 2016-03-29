using UnityEngine;
using System.Collections;

public class AssaultRifle : RangeWeapons {

	private Bullet bullet;
	public float firingSpeed;
	private float nextFire = 0.0f;

	void Update () {

		mousePosition = Input.mousePosition;
		mousePosition.z = -Camera.main.transform.position.z;
		shootingDirection = (Vector2)Camera.main.ScreenToWorldPoint (mousePosition) - (Vector2)transform.position;

		if (Input.GetMouseButton(0) && Time.time > nextFire)
		{
			nextFire = Time.time + (1/firingSpeed);
			//Instance the bullet and give it an initial speed in the direction of the mouse
			projectileInstance = (GameObject)Instantiate(projectile, firingPosition.position, firingPosition.rotation);
			projectileInstance.GetComponent<Rigidbody2D>().velocity = (shootingDirection.normalized * projectileSpeed);

		}
	}
}
