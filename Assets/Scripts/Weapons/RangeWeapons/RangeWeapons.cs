using UnityEngine;
using System.Collections;

public class RangeWeapons : MonoBehaviour {

	public float projectileSpeed;
	public Transform firingPosition;
	public GameObject projectile;
	protected GameObject projectileInstance;
	protected Vector2 shootingDirection;
	protected Vector3 mousePosition;
	private AudioSource source;
	public AudioClip weaponSound;

	public virtual void Start(){
		source = GetComponent<AudioSource>();
	}

	public void PlayWeaponSound(){
		source.PlayOneShot(weaponSound, 1F);
	}
}
