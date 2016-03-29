﻿using UnityEngine;
using System.Collections;

public class Pistol : RangeWeapons {

	Bullet bullet;


	void Update () {

		mousePosition = Input.mousePosition;
		mousePosition.z = -Camera.main.transform.position.z;
		shootingDirection = (Vector2)Camera.main.ScreenToWorldPoint (mousePosition) - (Vector2)transform.position;

		if (Input.GetMouseButtonDown(0))
		{
			//Instance the bullet and give it an initial speed in the direction of the mouse
			projectileInstance = (GameObject)Instantiate(projectile, firingPosition.position, firingPosition.rotation);
			projectileInstance.GetComponent<Rigidbody2D>().velocity = (shootingDirection.normalized * projectileSpeed);

		}
	}
}
