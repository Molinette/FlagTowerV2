using UnityEngine;
using System.Collections;

public class Bomber : Enemy {
	public GameObject explosion;
	private GameObject tower;
    private GameObject character;
    private bool isTowerDown  = false;
	private GameObject spawnManager;


	public override void Start(){
		base.Start();
		tower = GameObject.FindGameObjectWithTag("Tower");
        character = GameObject.FindGameObjectWithTag("Character");
		target = tower.transform;
		spawnManager = GameObject.Find("SpawnManager");
		spawnManager.GetComponent<EnemiesCounter> ().IncBomber();
	}
    
    void Update (){

		//Looks if the tower is down
        if (tower.GetComponent<TowerDownScript>().getCurrentStep() <= 0){
            isTowerDown = true;
            target = character.transform;
        }


    }

	void OnCollisionEnter2D(Collision2D collision){
		
		if(!collision.collider.gameObject.CompareTag("Ground")){
			if(collision.collider.gameObject.CompareTag("Tower")&&!isTowerDown){
				Damage();
			}

			//If there is a collision with the player, sends him flying at a 45 degree angle in the opposite direction
			if(collision.collider.gameObject.CompareTag("Character")){
				float directionX = (collision.collider.gameObject.transform.position.x - transform.position.x) / Mathf.Abs (collision.collider.gameObject.transform.position.x - transform.position.x);
				collision.collider.gameObject.transform.parent.GetComponent<PlayerController> ().Push(new Vector2(directionX,1));
			}
			ReceiveDamage(1);
		}
	}

	//Applies damage to the tower
	public override void Damage () {
		tower.GetComponent<TowerDownScript>().changeHealth(-damage);
	}

	public override void ReceiveDamage (float damage) {
		curr_health -= damage;
		if (curr_health <= 0) {
			//Creates an explosion
			GameObject.Instantiate(explosion,transform.position,explosion.transform.rotation);
			Destroy(gameObject);
		} else {
			SetHealthBar (this.curr_health / this.max_health);
		}
	}
}
