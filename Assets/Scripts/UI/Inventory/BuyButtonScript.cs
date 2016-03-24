using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BuyButtonScript : MonoBehaviour {
    
    public string item;
    public PlayerInventory playerInventory;

    public Text ItemPriceText;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        ItemPriceText.text = playerInventory.getPrice(item) + "$";
    }
}
