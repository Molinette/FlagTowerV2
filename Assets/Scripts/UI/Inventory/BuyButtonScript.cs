using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BuyButtonScript : Button {
    
    public string item;
    private PlayerInventory playerInventory;

    public Text ItemPriceText;

	// Use this for initialization
	void Start () {
        playerInventory = GameObject.Find("Character").GetComponent<PlayerInventory>();
		ItemPriceText.text = playerInventory.getPrice(item) + "$";
    }
	
	// Update is called once per frame
	void Update () {
        ItemPriceText.text = playerInventory.getPrice(item) + "$";
        if(playerInventory.getMoney() > playerInventory.getPrice(item))
        {
            this.interactable = false;
        }
        else
        {
            this.interactable = true;
        }

    }
}
