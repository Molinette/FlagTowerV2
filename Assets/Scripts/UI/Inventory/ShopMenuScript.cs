using UnityEngine;
using System.Collections;

public class ShopMenuScript : MonoBehaviour {

    private PlayerInventory playerInventory;

    private GameObject[] inventoryButtons;

    // Use this for initialization
    void Start () {
        inventoryButtons = GameObject.FindGameObjectsWithTag("InventoryButton");
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OpenShop()
    {
        this.transform.position = new Vector3(0f, transform.position.y, 0f);
    }
}
