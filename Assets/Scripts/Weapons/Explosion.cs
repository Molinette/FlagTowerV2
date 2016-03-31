using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		Destroy(gameObject,2f);
	}
}
