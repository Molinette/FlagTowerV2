using UnityEngine;
using System.Collections;

public class CharacterIgnoreCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Character"), LayerMask.NameToLayer("Flag"));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
