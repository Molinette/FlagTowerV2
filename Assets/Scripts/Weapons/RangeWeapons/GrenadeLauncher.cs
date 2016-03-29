﻿using UnityEngine;
using System.Collections;

public class GrenadeLauncher : RangeWeapons {

	public float maxThrowingForce;
	public float forceIncrement;
	private float currentThrowingForce;

	// Update is called once per frame
	void Update () {

		mousePosition = Input.mousePosition;
		mousePosition.z = -Camera.main.transform.position.z;
		shootingDirection = (Vector2)Camera.main.ScreenToWorldPoint (mousePosition) - (Vector2)transform.position;

		if (Input.GetMouseButtonDown(0)){
			currentThrowingForce = 0;
		}

		if(Input.GetMouseButton(0)){
			currentThrowingForce = Mathf.Min(currentThrowingForce + forceIncrement*Time.deltaTime, maxThrowingForce); 
		}

		if(Input.GetMouseButtonUp(0)){
			//Instance the bullet and give it an initial speed in the direction of the mouse
			projectileInstance = (GameObject)Instantiate(projectile, firingPosition.position, firingPosition.rotation);
			projectileInstance.GetComponent<Rigidbody2D>().AddForce(shootingDirection.normalized * currentThrowingForce,ForceMode2D.Impulse);
		}
	}

}
