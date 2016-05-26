using UnityEngine;
using System.Collections;

public class Bomber : Enemy {
	public GameObject explosion;
	private GameObject tower;
    private GameObject character;
    private bool isTowerDown  = false;
	private GameObject spawnManager;
	private Vector2 directionDuPush = new Vector2(1,1);


	public override void Start(){
		base.Start();
		tower = GameObject.FindGameObjectWithTag("Tower");
        character = GameObject.FindGameObjectWithTag("Character");
		target = tower.transform;
		spawnManager = GameObject.Find("SpawnManager");
		spawnManager.GetComponent<EnemiesCounter> ().IncBomber();
	}
    
    void Update (){

        if (tower.GetComponent<TowerDownScript>().getCurrentStep() == 0){

            isTowerDown = true;
            target = character.transform;
        }

        else{

            isTowerDown = false;
            target = tower.transform;
        }


    }

	void OnCollisionEnter2D(Collision2D collision){
		if(!collision.collider.gameObject.CompareTag("Ground")){
			if(collision.collider.gameObject.CompareTag("Tower")&&!isTowerDown){
				Damage();
			}

			if(collision.collider.gameObject.CompareTag("Character")&&isTowerDown){
				float directionX = (collision.collider.gameObject.transform.position.x - transform.position.x) / Mathf.Abs (collision.collider.gameObject.transform.position.x - transform.position.x);
				collision.collider.gameObject.transform.parent.GetComponent<PlayerController> ().Push(new Vector2(directionX,1));
			}

			GameObject.Instantiate(explosion,transform.position,explosion.transform.rotation);
			Destroy(gameObject);
		}
	}

	public override void Damage () {
		tower.GetComponent<TowerDownScript>().changeHealth(-damage);
	}
}
