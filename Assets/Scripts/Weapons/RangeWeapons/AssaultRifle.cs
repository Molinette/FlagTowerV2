using UnityEngine;
using System.Collections;

public class AssaultRifle : RangeWeapons {

	public override void Start(){
		base.Start ();
	}

	public override void Update () {
		base.Update ();
		mousePosition = Input.mousePosition;
		mousePosition.z = -Camera.main.transform.position.z;
		shootingDirection = (Vector2)Camera.main.ScreenToWorldPoint (mousePosition) - (Vector2)transform.position;

		if (Input.GetMouseButton(0) && firingTimer >= firingCooldown)
		{
			firingTimer = 0;
			PlayWeaponSound ();
			//Instance the bullet and give it an initial speed in the direction of the mouse
			projectileInstance = (GameObject)Instantiate(projectile, firingPosition.position, firingPosition.rotation);
			projectileInstance.GetComponent<Rigidbody2D>().velocity = (shootingDirection.normalized * projectileSpeed);
		}
	}
}
