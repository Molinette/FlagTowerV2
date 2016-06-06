using UnityEngine;
using System.Collections;

public class Enemy : EnemyBehaviour {

	public float damage; 
	public float max_health;
	protected float curr_health;
	public GameObject health_bar;
	protected GameManager gameManager;

	//Target to follow
	public Animator animation;

	public override void Start(){
		base.Start();
		curr_health = max_health;
		gameManager = Camera.main.GetComponent<GameManager>();
	}

	public virtual void Damage () {
		
	}

	public virtual void ReceiveDamage (float damage) {
		curr_health -= damage;
		if (curr_health <= 0) {
			gameManager.RemoveEnemy();
			Destroy (this.gameObject);
		} else {
			SetHealthBar (this.curr_health / this.max_health);
		}
	}

	public void SetHealthBar(float enemyHealth) {
		this.health_bar.transform.localScale = new Vector3 (enemyHealth, this.health_bar.transform.localScale.y ,
		this.health_bar.transform.localScale.z);
	}
}
