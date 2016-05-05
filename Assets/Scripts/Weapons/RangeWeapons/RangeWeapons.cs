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

	public virtual void Start(){
		source = GetComponent<AudioSource>();
		firingTimer = firingCooldown;
	}
		
	public virtual void Update(){
	
		firingTimer += Time.deltaTime;
	}

	public void PlayWeaponSound(){
		source.PlayOneShot(weaponSound, 1F);
	}
}
