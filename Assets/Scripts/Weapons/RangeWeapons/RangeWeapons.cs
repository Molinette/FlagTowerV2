using UnityEngine;
using System.Collections;

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
    public PlayerInventory playerInventory;

	public virtual void Start(){
		source = GetComponent<AudioSource>();
		firingTimer = firingCooldown;
        ammunition = 0;
    }
		
	public virtual void Update(){
	
		firingTimer += Time.deltaTime;
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
