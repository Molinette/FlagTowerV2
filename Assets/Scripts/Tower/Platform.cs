using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour {
	public Collider2D platformCollider;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){

		//If there is a PlatformDetecor, disable collision till exit
		if(other.gameObject.name == "PlatformDetector"){
			Component[] otherColliders;
			otherColliders = other.gameObject.transform.parent.GetComponentsInChildren<Collider2D>();
			foreach(Collider2D collider in otherColliders){
				Physics2D.IgnoreCollision(platformCollider,collider,true);
			}
		}
	}

	//If there is a PlatformDetecor, reenable collision
	void OnTriggerExit2D(Collider2D other){
		if(other.gameObject.name == "PlatformDetector"){
			Component[] otherColliders;
			otherColliders = other.gameObject.transform.parent.GetComponentsInChildren<Collider2D>();
			foreach(Collider2D collider in otherColliders){
				Physics2D.IgnoreCollision(platformCollider,collider,false);
			}
		}
	}
}
