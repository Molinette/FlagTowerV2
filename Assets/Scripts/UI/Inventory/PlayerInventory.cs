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

    public Pistol pistol;
    //public Katana katana;
    public AssaultRifle rifle;
    public Shotgun shotgun;
    public RocketLauncher rpg;
    public GrenadeLauncher grenadeLauncher;
    public Placeable turret;
    public Placeable mine;

    public void Start()
    {
        inventoryButtons = GameObject.FindGameObjectsWithTag("InventoryButton");
        Array.Sort(inventoryButtons, CompareObNames);



        itemPrices[KATANA] = ConstantInventoryValues.KATANA_INITIAL_COST;
        itemPrices[RIFLE] = ConstantInventoryValues.RIFLE_INITIAL_COST;
        itemPrices[SHOTGUN] = ConstantInventoryValues.SHOTGUN_INITIAL_COST;
        itemPrices[RPG] = ConstantInventoryValues.RPG_INITIAL_COST;
        itemPrices[GRENADELAUNCHER] = ConstantInventoryValues.GRENADELAUNCHER_INITIAL_COST;
        itemPrices[TURRET] = ConstantInventoryValues.TURRET_COST;
        itemPrices[MINE] = ConstantInventoryValues.MINE_COST;
        itemPrices[TOWERHEALTH] = ConstantInventoryValues.TOWER_HEALTH_COST;
        itemPrices[TOWERARMOR] = ConstantInventoryValues.TOWER_ARMOR_COST;
        refreshMoneyText();
        
    }

    public void addItem(string item)
    {
        switch (item)
        {
            case ConstantInventoryValues.KATANA:
                if (Pay(itemPrices[KATANA])) {
                    if (itemPrices[KATANA] == ConstantInventoryValues.KATANA_INITIAL_COST)
                    {
                        inventory[KATANA] += 1;
                        inventoryButtons[KATANA].GetComponent<ButtonPlayerAction>().RefreshText(inventory[KATANA].ToString());
                        itemPrices[KATANA] = 0;
                    }                    
                }
                break;
            case ConstantInventoryValues.ASSAULT_RIFLE:
                if (Pay(itemPrices[RIFLE]))
                {
                    if (itemPrices[RIFLE] <= ConstantInventoryValues.RIFLE_INITIAL_COST)
                    {
                        itemPrices[RIFLE] = ConstantInventoryValues.RIFLE_AMMO_COST;
                    }
                    inventory[RIFLE] += ConstantInventoryValues.RIFLE_AMMO_TO_ADD;
                    rifle.addAmmo(ConstantInventoryValues.RIFLE_AMMO_TO_ADD);
                    inventoryButtons[RIFLE].GetComponent<ButtonPlayerAction>().RefreshText(inventory[RIFLE].ToString());
                }
                break;
            case ConstantInventoryValues.SHOTGUN:
                if (Pay(itemPrices[SHOTGUN]))
                {
                    if (itemPrices[SHOTGUN] <= ConstantInventoryValues.SHOTGUN_INITIAL_COST)
                    {
                        itemPrices[SHOTGUN] = ConstantInventoryValues.SHOTGUN_AMMO_COST;
                    }
                    inventory[SHOTGUN] += ConstantInventoryValues.SHOTGUN_AMMO_TO_ADD;
                    shotgun.addAmmo(ConstantInventoryValues.SHOTGUN_AMMO_TO_ADD);
                    inventoryButtons[SHOTGUN].GetComponent<ButtonPlayerAction>().RefreshText(inventory[SHOTGUN].ToString());
                }
                break;
            case ConstantInventoryValues.RPG:
                if (Pay(itemPrices[RPG]))
                {
                    if (itemPrices[RPG] <= ConstantInventoryValues.RPG_INITIAL_COST)
                    {
                        itemPrices[RPG] = ConstantInventoryValues.RPG_AMMO_COST;
                    }
                    inventory[RPG] += ConstantInventoryValues.RPG_AMMO_TO_ADD;
                    rpg.addAmmo(ConstantInventoryValues.RPG_AMMO_TO_ADD);
                    inventoryButtons[RPG].GetComponent<ButtonPlayerAction>().RefreshText(inventory[RPG].ToString());
                }
                break;
            case ConstantInventoryValues.GRENADE_LAUNCHER:
                if (Pay(itemPrices[GRENADELAUNCHER]))
                {
                    if (itemPrices[GRENADELAUNCHER] <= ConstantInventoryValues.GRENADELAUNCHER_INITIAL_COST)
                    {
                        itemPrices[GRENADELAUNCHER] = ConstantInventoryValues.GRENADELAUNCHER_AMMO_COST;
                    }
                    inventory[GRENADELAUNCHER] += ConstantInventoryValues.GRENADELAUNCHER_AMMO_TO_ADD;
                    grenadeLauncher.addAmmo(ConstantInventoryValues.GRENADELAUNCHER_AMMO_TO_ADD);
                    inventoryButtons[GRENADELAUNCHER].GetComponent<ButtonPlayerAction>().RefreshText(inventory[GRENADELAUNCHER].ToString());
                }
                break;
            case ConstantInventoryValues.TURRET:
                if (Pay(itemPrices[TURRET]))
                {
                    inventory[TURRET] += ConstantInventoryValues.TURRET_SUPPLY_TO_ADD;
                    turret.addAmmo(ConstantInventoryValues.TURRET_SUPPLY_TO_ADD);
                    inventoryButtons[TURRET].GetComponent<ButtonPlayerAction>().RefreshText(inventory[TURRET].ToString());
                }
                break;
            case ConstantInventoryValues.MINE:
                if (Pay(itemPrices[MINE]))
                {
                    inventory[MINE] += ConstantInventoryValues.MINE_SUPPLY_TO_ADD;
                    mine.addAmmo(ConstantInventoryValues.MINE_SUPPLY_TO_ADD);
                    inventoryButtons[MINE].GetComponent<ButtonPlayerAction>().RefreshText(inventory[MINE].ToString());
                }
                break;
            case ConstantInventoryValues.TOWER_HEALTH:
                if (Pay(itemPrices[TOWERHEALTH]))
                {
                    tower.changeHealth(20);
                }
                break;
            case ConstantInventoryValues.TOWER_ARMOR:
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
