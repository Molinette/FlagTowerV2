using UnityEngine;
using System.Collections;

public class MonsterIgnoreCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Character"), LayerMask.NameToLayer("Monster"));
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Flag"), LayerMask.NameToLayer("Monster"));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
