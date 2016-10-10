using UnityEngine;
using System.Collections;

public class flipCharacter : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.mousePosition.x > Camera.main.WorldToScreenPoint(transform.position).x){
			transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x),transform.localScale.y);
		}
		else{
			transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x)*-1,transform.localScale.y);
		}

	}
}
