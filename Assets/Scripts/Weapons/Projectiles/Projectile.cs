using UnityEngine;
using System.Collections;

public abstract class Projectile : MonoBehaviour {

    private AudioSource source;
    public AudioClip projectileSound;
	protected float damage;

	public void SetDamage(float damage){

		this.damage = damage;
	}

	public float GetDamage(){
	
		return damage;
	}

    public void PlayDestroyedSound()    {

        source.PlayOneShot(projectileSound, 1F);

    }


}
