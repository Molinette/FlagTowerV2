using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BuyButtonScript : MonoBehaviour {
    
    public string item;
    private PlayerInventory playerInventory;

    public Text ItemPriceText;

	// Use this for initialization
	void Start () {
        playerInventory = GameObject.FindGameObjectWithTag("Character").GetComponent<PlayerInventory>();
    }
	
	// Update is called once per frame
	void Update () {
        ItemPriceText.text = playerInventory.getPrice(item) + "$";
    }
}
