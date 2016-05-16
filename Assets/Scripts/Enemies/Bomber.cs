using UnityEngine;
using System.Collections;

public class Bomber : Enemy {
	public GameObject explosion;
	private GameObject tower;
    private GameObject character;
    private bool isTowerDown  = false;

	public override void Start(){
		base.Start();
		tower = GameObject.FindGameObjectWithTag("Tower");
        character = GameObject.FindGameObjectWithTag("Character");
		target = tower.transform;
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
           
			GameObject.Instantiate(explosion,transform.position,explosion.transform.rotation);
			Destroy(gameObject);
		}
	}

	public override void Damage () {
		tower.GetComponent<TowerDownScript>().changeHealth(-damage);
	}
}
