using UnityEngine;
using System.Collections;

public class RocketLauncher : RangeWeapons {
	//If the rocket launcher's missiles follow the cursor when left mouse is pressed
	public bool isHoming = false;

	public override void Start(){
		base.Start ();
	}

	// Update is called once per frame
	public override void Update () {

		base.Update ();
		mousePosition = Input.mousePosition;
		mousePosition.z = -Camera.main.transform.position.z;
		shootingDirection = (Vector2)Camera.main.ScreenToWorldPoint (mousePosition) - (Vector2)transform.position;

		if(Input.GetMouseButtonDown(0)  && firingTimer >= firingCooldown && ammunition > 0 && canShoot)
        {
			firingTimer = 0;
			PlayWeaponSound ();
			//Instance the bullet and give it an initial speed in the direction of the mouse
			projectileInstance = (GameObject)Instantiate (projectile, firingPosition.position, firingPosition.rotation);
			if (character.transform.localScale.x < 0) {
				projectileInstance.transform.eulerAngles = new Vector3 (projectileInstance.transform.eulerAngles.x, projectileInstance.transform.eulerAngles.y, -projectileInstance.transform.eulerAngles.z);
			}
            projectileInstance.GetComponent<Rigidbody2D>().velocity = (shootingDirection.normalized * projectileSpeed);
            projectileInstance.GetComponent<Missile>().SetMissileSpeed(projectileSpeed);
			projectileInstance.GetComponent<Missile> ().SetIsHoming (isHoming);
			projectileInstance.GetComponent<Projectile>().SetDamage(damage);
            playerInventory.useItem(ConstantInventoryValues.RPG);
            FireAmmo();
        }
	}
}