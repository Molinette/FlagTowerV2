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
    private const int GRENADELAUNCHER = 5;
    private const int TURRET = 6;
    private const int MINE = 7;
    private const int TOWERHEALTH = 8;
    private const int TOWERARMOR = 9;

    private int money = 50000;

    private int[] inventory = new int[8];

    private int[] itemPrices = new int[10];

    private GameObject[] inventoryButtons;

    public Text moneyText;
    public TowerDownScript tower;

    public void Start()
    {
        inventoryButtons = GameObject.FindGameObjectsWithTag("InventoryButton");
        Array.Sort(inventoryButtons, CompareObNames);



        itemPrices[KATANA] = ConstantInventoryValues.Katana_Initial_Cost;
        itemPrices[RIFLE] = ConstantInventoryValues.Rifle_Initial_Cost;
        itemPrices[SHOTGUN] = ConstantInventoryValues.Shotgun_Initial_Cost;
        itemPrices[RPG] = ConstantInventoryValues.RPG_Initial_Cost;
        itemPrices[GRENADELAUNCHER] = ConstantInventoryValues.GrenadeLauncher_Initial_Cost;
        itemPrices[TURRET] = ConstantInventoryValues.Turret_Cost;
        itemPrices[MINE] = ConstantInventoryValues.Mine_Cost;
        itemPrices[TOWERHEALTH] = ConstantInventoryValues.Tower_Health_Cost;
        itemPrices[TOWERARMOR] = ConstantInventoryValues.Tower_Armor_Cost;
        refreshMoneyText();
        
    }

    public void addItem(string item)
    {
        switch (item)
        {
            case "Katana":
                if (Pay(itemPrices[KATANA])) {
                    if (itemPrices[KATANA] == ConstantInventoryValues.Katana_Initial_Cost)
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
                    if (itemPrices[RIFLE] <= ConstantInventoryValues.Rifle_Initial_Cost)
                    {
                        itemPrices[RIFLE] = ConstantInventoryValues.Rifle_Ammo_Cost;
                    }
                    inventory[RIFLE] += 30;
                    inventoryButtons[RIFLE].GetComponent<ButtonPlayerAction>().RefreshText(inventory[RIFLE].ToString());
                }
                break;
            case "Shotgun":
                if (Pay(itemPrices[SHOTGUN]))
                {
                    if (itemPrices[SHOTGUN] <= ConstantInventoryValues.Shotgun_Initial_Cost)
                    {
                        itemPrices[SHOTGUN] = ConstantInventoryValues.Shotgun_Ammo_Cost;
                    }
                    inventory[SHOTGUN] += 8;
                    inventoryButtons[SHOTGUN].GetComponent<ButtonPlayerAction>().RefreshText(inventory[SHOTGUN].ToString());
                }
                break;
            case "RPG":
                if (Pay(itemPrices[RPG]))
                {
                    if (itemPrices[RPG] <= ConstantInventoryValues.RPG_Initial_Cost)
                    {
                        itemPrices[RPG] = ConstantInventoryValues.RPG_Ammo_Cost;
                    }
                    inventory[RPG] += 1;
                    inventoryButtons[RPG].GetComponent<ButtonPlayerAction>().RefreshText(inventory[RPG].ToString());
                }
                break;
            case "GrenadeLauncher":
                if (Pay(itemPrices[GRENADELAUNCHER]))
                {
                    if (itemPrices[GRENADELAUNCHER] <= ConstantInventoryValues.GrenadeLauncher_Initial_Cost)
                    {
                        itemPrices[GRENADELAUNCHER] = ConstantInventoryValues.GrenadeLauncher_Ammo_Cost;
                    }
                    inventory[GRENADELAUNCHER] += 1;
                    inventoryButtons[GRENADELAUNCHER].GetComponent<ButtonPlayerAction>().RefreshText(inventory[GRENADELAUNCHER].ToString());
                }
                break;
            case "Turret":
                if (Pay(itemPrices[TURRET]))
                {
                    inventory[TURRET] += 2;
                    inventoryButtons[TURRET].GetComponent<ButtonPlayerAction>().RefreshText(inventory[TURRET].ToString());
                }
                break;
            case "Mine":
                if (Pay(itemPrices[MINE]))
                {
                    inventory[MINE] += 2;
                    inventoryButtons[MINE].GetComponent<ButtonPlayerAction>().RefreshText(inventory[MINE].ToString());
                }
                break;
            case "TowerHealth":
                if (Pay(itemPrices[TOWERHEALTH]))
                {
                    tower.changeHealth(20);
                }
                break;
            case "TowerArmor":
                if (Pay(itemPrices[TOWERARMOR]))
                {
                    //Temporairement un moyen de rapidement endommager la tour
                    tower.changeHealth(-20);
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

    public int getPrice(string item)
    {
        switch (item)
        {
            case "Katana":
                return itemPrices[KATANA];
            case "Rifle":
                return itemPrices[RIFLE];
            case "Shotgun":
                return itemPrices[SHOTGUN];
            case "RPG":
                return itemPrices[RPG];
            case "GrenadeLauncher":
                return itemPrices[GRENADELAUNCHER];
            case "Turret":
                return itemPrices[TURRET];
            case "Mine":
                return itemPrices[MINE];
            case "TowerHealth":
                return itemPrices[TOWERHEALTH];
            case "TowerArmor":
                return itemPrices[TOWERARMOR];
            default:
                return 0;
        }
    }

    public void useItem(string item)
    {
        switch (item)
        {
            case "Pistol":
                Debug.Log("Use Pistol");
                break;
            case "Katana":
                if(inventory[KATANA] > 0)
                {
                    Debug.Log("Use Katana");
                }
                break;
            case "Rifle":
                if (inventory[RIFLE] > 0)
                {
                    inventory[RIFLE] = inventory[RIFLE] - 1;
                    inventoryButtons[RIFLE].GetComponent<ButtonPlayerAction>().RefreshText(inventory[RIFLE].ToString());
                    Debug.Log("Use Rifle");
                }
                break;
            case "Shotgun":
                if (inventory[SHOTGUN] > 0)
                {
                    inventory[SHOTGUN] = inventory[SHOTGUN] - 1;
                    inventoryButtons[SHOTGUN].GetComponent<ButtonPlayerAction>().RefreshText(inventory[SHOTGUN].ToString());
                    Debug.Log("Use Shotgun");
                }
                break;
            case "RPG":
                if (inventory[RPG] > 0)
                {
                    inventory[RPG] = inventory[RPG] - 1;
                    inventoryButtons[RPG].GetComponent<ButtonPlayerAction>().RefreshText(inventory[RPG].ToString());
                    Debug.Log("Use RPG");
                }
                break;
            case "GrenadeLauncher":
                if (inventory[GRENADELAUNCHER] > 0)
                {
                    inventory[GRENADELAUNCHER] = inventory[GRENADELAUNCHER] - 1;
                    inventoryButtons[GRENADELAUNCHER].GetComponent<ButtonPlayerAction>().RefreshText(inventory[GRENADELAUNCHER].ToString());
                    Debug.Log("Use Grenade Launcher");
                }
                
                break;
            case "Turret":
                if (inventory[TURRET] > 0)
                {
                    inventory[TURRET] = inventory[TURRET] - 1;
                    inventoryButtons[TURRET].GetComponent<ButtonPlayerAction>().RefreshText(inventory[TURRET].ToString());
                    Debug.Log("Place Turret");
                }
                break;
            case "Mine":
                if (inventory[MINE] > 0)
                {
                    inventory[MINE] = inventory[MINE] - 1;
                    inventoryButtons[MINE].GetComponent<ButtonPlayerAction>().RefreshText(inventory[MINE].ToString());
                    Debug.Log("Place Mine");
                }
                break;
            default:
                break;
        }
    }
}
