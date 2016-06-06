﻿using UnityEngine;
using System.Collections;

public class GrenadePrototype : MonoBehaviour {
	public float damage;
	public float timer;
	public float explosionForce;
	public float explosionRadius;
	public GameObject explosionPrefab;
    private AudioSource source;
    public AudioClip grenadeSound;

    // Use this for initialization
    void Start () {

        source = GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update () {

		timer -= Time.deltaTime;
		if(timer <= 0){
			Explode();
			GameObject.Instantiate(explosionPrefab,transform.position,Quaternion.Euler(explosionPrefab.transform.eulerAngles));
			Destroy(gameObject);
		}
	}

	void Explode(){

        PlayGrenadeSound();

		Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position,explosionRadius);
		foreach(Collider2D collider in colliders){
			/*Rigidbody2D colliderRb = collider.gameObject.GetComponent<Rigidbody2D>();
			if(colliderRb != null){
				Vector2 direction = collider.transform.position - transform.position;
				colliderRb.AddForce(direction.normalized*explosionForce,ForceMode2D.Impulse);
			}*/
			if(collider.CompareTag("Hitbox")){
				if(collider.transform.parent.transform.CompareTag("Enemy")){
					collider.transform.parent.GetComponent<Enemy>().ReceiveDamage(damage);
				}
			}
		}
	}

    public void PlayGrenadeSound()
    {

        source.PlayOneShot(grenadeSound, 1F);

    }
}
