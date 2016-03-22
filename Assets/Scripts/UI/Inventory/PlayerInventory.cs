using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class PlayerInventory : MonoBehaviour {
    private const int PISTOL = 0;
    private const int KATANA = 1;
    private const int RIFLE = 2;
    private const int SHOTGUN = 3;
    private const int RPG = 4;
    private const int GRENADE = 5;
    private const int GRENADELAUNCHER = 6;
    private const int MINE = 7;

    private int money = 5000;

    private int[] inventory = new int[8];

    private int[] itemPrices = new int[8];

    private GameObject[] inventoryButtons;
    private GameObject[] shopButtons;

    public Text moneyText;

    public void Start()
    {
        inventoryButtons = GameObject.FindGameObjectsWithTag("InventoryButton");
        shopButtons = GameObject.FindGameObjectsWithTag("ShopButton");
        //Array.Sort(inventory, CompareObNames);

        itemPrices[KATANA] = 1000;
        itemPrices[RIFLE] = 1000;
        itemPrices[SHOTGUN] = 1000;
        itemPrices[RPG] = 1000;
        itemPrices[GRENADE] = 1000;
        itemPrices[GRENADELAUNCHER] = 1000;
        itemPrices[MINE] = 1000;
        refreshMoneyText();
        
    }

    public void addItem(string item)
    {
        switch (item)
        {
            case "Katana":
                if (Pay(itemPrices[KATANA])) {
                    if (itemPrices[KATANA] <= 1000)
                    {
                        inventory[KATANA] += 1;
                        inventoryButtons[KATANA].GetComponent<ButtonPlayerAction>().RefreshText(inventory[KATANA].ToString());
                        itemPrices[KATANA] = 0;
                    }                    
                }
                break;
            case "Rifle":
                if (Pay(itemPrices[RIFLE]))
                {
                    if (itemPrices[RIFLE] <= 1000)
                    {
                        itemPrices[RIFLE] = 25;
                    }
                    inventory[RIFLE] += 30;
                    inventoryButtons[RIFLE].GetComponent<ButtonPlayerAction>().RefreshText(inventory[RIFLE].ToString());
                }
                break;
            case "Shotgun":
                if (Pay(itemPrices[SHOTGUN]))
                {
                    if (itemPrices[SHOTGUN] <= 1000)
                    {
                        itemPrices[SHOTGUN] = 25;
                    }
                    inventory[SHOTGUN] += 8;
                    inventoryButtons[SHOTGUN].GetComponent<ButtonPlayerAction>().RefreshText(inventory[SHOTGUN].ToString());
                }
                break;
            case "RPG":
                if (Pay(itemPrices[RPG]))
                {
                    if (itemPrices[RPG] <= 1000)
                    {
                        itemPrices[RPG] = 25;
                    }
                    inventory[RPG] += 1;
                    inventoryButtons[RPG].GetComponent<ButtonPlayerAction>().RefreshText(inventory[RPG].ToString());
                }
                break;
            case "Grenade":
                if (Pay(itemPrices[GRENADE]))
                {
                    if (itemPrices[GRENADE] <= 1000)
                    {
                        itemPrices[GRENADE] = 25;
                    }
                    inventory[GRENADE] += 2;
                    inventoryButtons[GRENADE].GetComponent<ButtonPlayerAction>().RefreshText(inventory[GRENADE].ToString());
                }
                break;
            case "GrenadeLauncher":
                if (Pay(itemPrices[GRENADELAUNCHER]))
                {
                    if (itemPrices[GRENADELAUNCHER] <= 1000)
                    {
                        itemPrices[GRENADELAUNCHER] = 25;
                    }
                    inventory[GRENADELAUNCHER] += 1;
                    inventoryButtons[GRENADELAUNCHER].GetComponent<ButtonPlayerAction>().RefreshText(inventory[GRENADELAUNCHER].ToString());
                }
                break;
            case "Mine":
                if (Pay(itemPrices[MINE]))
                {
                    if (itemPrices[MINE] <= 1000)
                    {
                        itemPrices[MINE] = 25;
                    }
                    inventory[MINE] += 2;
                    inventoryButtons[MINE].GetComponent<ButtonPlayerAction>().RefreshText(inventory[MINE].ToString());
                }
                break;
            default:
                break;
        }
        refreshMoneyText();
    }

    public bool Pay(int cost)
    {
        if(cost <= money)
        {
            money -= cost;
            return true;
        }
        else
        {
            return false;
        }
        
    }

    int CompareObNames(GameObject x, GameObject y)
    {
        return x.name.CompareTo(y.name);
    }

    private void refreshMoneyText()
    {
        moneyText.text = money.ToString() + "$";
    }
}
