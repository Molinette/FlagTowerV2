using UnityEngine;
using System.Collections;

public class Missile : Explosive {

	//The rocket force
	public float missileAcceleration;
	//Does it follow the cursor when left mous is pressed?
	private bool isHoming = false;
	public float explosionForce;
	private float startingAngle = 90;
	private GameObject rocketLauncher;
	protected Vector2 direction;
	protected Vector3 mousePosition;

	void Update(){

		if (Input.GetMouseButtonDown (1) && isHoming) {
			//Get direction to cursor
			mousePosition = Input.mousePosition;
			mousePosition.z = -Camera.main.transform.position.z;
			direction = (Vector2)Camera.main.ScreenToWorldPoint (mousePosition) - (Vector2)transform.position;

			//Rotate the missile
			float rotationZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - startingAngle;
			transform.eulerAngles = new Vector3(0, 0, rotationZ);

			//Give velocity to cursor
			GetComponent<Rigidbody2D> ().velocity = direction.normalized*20;
		} else {
			GetComponent<Rigidbody2D> ().AddForce (transform.TransformDirection (Vector2.up) * missileAcceleration);
		}
	}

	void OnCollisionEnter2D(Collision2D collision){

			Explode ();
			GameObject.Instantiate (explosionPrefab, transform.position, Quaternion.Euler (explosionPrefab.transform.eulerAngles));
			Destroy (gameObject);
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

	public void SetIsHoming(bool isHoming){
		this.isHoming = isHoming;
	}

}
