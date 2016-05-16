using UnityEngine;
using System.Collections;

public class Bomber : Enemy {
	public GameObject explosion;
	private GameObject tower;
	private GameObject spawnManager;

	public override void Start(){
		base.Start();
		tower = GameObject.FindGameObjectWithTag("Tower");
		target = tower.transform;
		spawnManager = GameObject.Find("SpawnManager");
		spawnManager.GetComponent<EnemiesCounter> ().IncBomber();
	}

	void OnCollisionEnter2D(Collision2D collision){
		if(!collision.collider.gameObject.CompareTag("Ground")){
			if(collision.collider.gameObject.CompareTag("Tower")){
				Damage();
			}
			GameObject.Instantiate(explosion,transform.position,explosion.transform.rotation);
			Destroy(gameObject);
		}
	}

	public override void Damage () {
		tower.GetComponent<TowerDownScript>().changeHealth(-damage);
	}
}
