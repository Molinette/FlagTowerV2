using UnityEngine;
using System.Collections;

public class Placeable : MonoBehaviour {
	private bool isPlaced = false;
	private bool inTrapZone = false;
	public GameObject trapPrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		LayerMask trapZoneLayer = LayerMask.NameToLayer("TrapZone");
		RaycastHit2D hit;
		Vector3 bounds = GetComponent<SpriteRenderer>().bounds.size;
		Vector3 mousePosition = Input.mousePosition;
		Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
		mouseWorldPosition.z = 0;
		hit = Physics2D.Raycast(mouseWorldPosition,Vector2.zero,Mathf.Infinity, 1 << trapZoneLayer);

		if(!isPlaced){
			if(hit.collider != null){
				inTrapZone = true;
			} else {
				inTrapZone = false;
			}
			if(inTrapZone){
				LayerMask placeableZoneLayer = LayerMask.NameToLayer("TrapGround");
				hit = Physics2D.Raycast(mouseWorldPosition,Vector2.down, Mathf.Infinity, 1 << placeableZoneLayer);
				transform.position = new Vector2(Mathf.Floor(mouseWorldPosition.x)+bounds.x/2,hit.point.y+bounds.y/2);
				if(Input.GetMouseButtonDown(1)){
					GameObject.Instantiate(trapPrefab,transform.position, Quaternion.Euler(trapPrefab.transform.eulerAngles));
				}
			} else{
				transform.position = new Vector2(mouseWorldPosition.x,mouseWorldPosition.y);
			}
		}
	}

	void FixedUpdate(){
	}
}
