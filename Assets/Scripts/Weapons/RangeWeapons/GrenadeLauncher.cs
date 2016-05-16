using UnityEngine;
using System.Collections;

public class GrenadeLauncher : RangeWeapons {

	public float throwingForce;

	public override void Start(){
		base.Start ();
	}

	// Update is called once per frame
	public override void Update () {

		base.Update ();
		mousePosition = Input.mousePosition;
		mousePosition.z = -Camera.main.transform.position.z;
		shootingDirection = (Vector2)Camera.main.ScreenToWorldPoint (mousePosition) - (Vector2)transform.position;

		if(Input.GetMouseButtonDown(0) && firingTimer >= firingCooldown && ammunition > 0)
        {
			firingTimer = 0;
			PlayWeaponSound ();
			//Instance the bullet and give it an initial speed in the direction of the mouse
			projectileInstance = (GameObject)Instantiate(projectile, firingPosition.position, firingPosition.rotation);
			projectileInstance.GetComponent<Rigidbody2D>().AddForce(shootingDirection.normalized * throwingForce,ForceMode2D.Impulse);
            //projectileInstance.GetComponent<Projectile>().SetDamage(damage);

            playerInventory.useItem(ConstantInventoryValues.GRENADE_LAUNCHER);
            FireAmmo();
        }

	}

}
