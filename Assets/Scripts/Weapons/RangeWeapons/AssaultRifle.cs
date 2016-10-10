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

		if (Input.GetMouseButton(0) && firingTimer >= firingCooldown && ammunition > 0 && canShoot)
		{
			firingTimer = 0;
			PlayWeaponSound ();
			//Instance the bullet and give it an initial speed in the direction of the mouse
			projectileInstance = (GameObject)Instantiate(projectile, firingPosition.position, firingPosition.rotation);
			projectileInstance.transform.eulerAngles = new Vector3 (projectileInstance.transform.eulerAngles.x, projectileInstance.transform.eulerAngles.y, projectileInstance.transform.eulerAngles.z);
			projectileInstance.GetComponent<Rigidbody2D>().velocity = (shootingDirection.normalized * projectileSpeed);
			projectileInstance.GetComponent<Projectile>().SetDamage(damage);
            playerInventory.useItem(ConstantInventoryValues.ASSAULT_RIFLE);
            FireAmmo();
		}
	}
}
