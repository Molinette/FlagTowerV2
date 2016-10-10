using UnityEngine;
using System.Collections;

public class AirStrikerBomb : MonoBehaviour {

	public float damage;
	public float timer;
	public float explosionRadius;
	public GameObject explosionPrefab;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		/*timer -= Time.deltaTime;
		if(timer <= 0){
			Explode();
			GameObject.Instantiate(explosionPrefab,transform.position,Quaternion.Euler(explosionPrefab.transform.eulerAngles));
			Destroy(gameObject);
		}
		*/
	}

	void Explode(){
		Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position,explosionRadius);
		foreach(Collider2D collider in colliders){
			if(collider.CompareTag("Tower")){
				collider.transform.parent.GetComponent<TowerDownScript>().changeHealth(-damage);
			}
		}
	}
	void OnCollisionEnter2D(Collision2D col){
		Explode();
		GameObject.Instantiate(explosionPrefab,transform.position,Quaternion.Euler(explosionPrefab.transform.eulerAngles));
		Destroy(gameObject);
	}
}
