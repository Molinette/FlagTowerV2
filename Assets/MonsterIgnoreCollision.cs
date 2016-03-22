using UnityEngine;
using System.Collections;

public class MonsterIgnoreCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Character"), LayerMask.NameToLayer("Enemy"));
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Flag"), LayerMask.NameToLayer("Enemy"));
		Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Enemy"), LayerMask.NameToLayer("Enemy"));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
