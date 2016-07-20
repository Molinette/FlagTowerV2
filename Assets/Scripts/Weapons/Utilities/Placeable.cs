using UnityEngine;
using System.Collections;

public class Placeable : MonoBehaviour {
	private bool isPlaced = false;
	private bool inTrapZone = false;
	public GameObject trapPrefab;
    protected int ammunition;
    public PlayerInventory playerInventory;

    public bool isTurret;
    public bool isMine;

    // Use this for initialization
    void Start () {
        ammunition = 0;
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
				LayerMask placeableZoneLayer = LayerMask.NameToLayer("Ground");
				hit = Physics2D.Raycast(mouseWorldPosition,Vector2.down, Mathf.Infinity, 1 << placeableZoneLayer);
				transform.position = new Vector2(Mathf.Floor(mouseWorldPosition.x)+bounds.x/2,hit.point.y+bounds.y/2);
				if(Input.GetMouseButtonDown(0) && ammunition > 0)
                {
                    GameObject.Instantiate(trapPrefab,new Vector2(transform.position.x,transform.position.y-bounds.y/2),
						Quaternion.Euler(trapPrefab.transform.eulerAngles));
                    if (isTurret)
                    {
                        playerInventory.useItem(ConstantInventoryValues.TURRET);
                    }
                    else if (isMine)
                    {
                        playerInventory.useItem(ConstantInventoryValues.MINE);
                    }
                    FireAmmo();
                }
			} else{
				transform.position = new Vector2(mouseWorldPosition.x,mouseWorldPosition.y);
			}
		}


	}

	void FixedUpdate(){
	}

    public void addAmmo(int ammunition)
    {
        this.ammunition += ammunition;
    }

    protected void FireAmmo()
    {
        if (ammunition > 0)
        {
            ammunition--;
        }
    }
}
