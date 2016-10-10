using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class RangeWeapons : MonoBehaviour {

	public float projectileSpeed;
	public Transform firingPosition;
	public GameObject projectile;
	public float damage;
	protected GameObject projectileInstance;
	protected Vector2 shootingDirection;
	protected Vector3 mousePosition;
	private AudioSource source;
	public AudioClip weaponSound;
	public float firingCooldown;
	protected float firingTimer;
    protected int ammunition;
	protected bool canShoot = true;
    public PlayerInventory playerInventory;
	protected GameObject character;

	public virtual void Start(){
		source = GetComponent<AudioSource>();
		firingTimer = firingCooldown;
        ammunition = 0;
		character = GameObject.Find ("Character");
    }
		
	public virtual void Update(){
		source.pitch = Time.timeScale;
		firingTimer += Time.deltaTime;
		if(EventSystem.current.IsPointerOverGameObject())
		{
			PointerEventData pointer = new PointerEventData(EventSystem.current);
			pointer.position = Input.mousePosition;

			List<RaycastResult> raycastResults = new List<RaycastResult>();
			EventSystem.current.RaycastAll(pointer, raycastResults);

			if(raycastResults.Count > 0)
			{
				if (raycastResults [0].gameObject.tag == "UIStopFire" || raycastResults [0].gameObject.tag == "InventoryButton")
					canShoot = false;
			}
		}
		else
			canShoot = true;

	}

	public void PlayWeaponSound(){
		source.PlayOneShot(weaponSound, 1F);
	}

    public void addAmmo(int ammunition)
    {
        this.ammunition += ammunition;
    }

    protected void FireAmmo(){
        if(ammunition > 0){
            ammunition--;
        }
    }

}
