using UnityEngine;
using System.Collections;

public class MinePrototype : MonoBehaviour {
	public float damage;
	public float explosionRadius;
	public GameObject explosionPrefab;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		
	}

	void Explode(){
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

	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("Enemy") || other.CompareTag("Character")){
			Explode();
			GameObject.Instantiate(explosionPrefab,transform.position,Quaternion.Euler(explosionPrefab.transform.eulerAngles));
			Destroy(gameObject);
		}
	}
}
