using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class PlayerInventory : MonoBehaviour {
    private const int PISTOL = 0;
    private const int RIFLE = 1;
    private const int SHOTGUN = 2;
    private const int RPG = 3;
    private const int GRENADELAUNCHER = 4;
    private const int TURRET = 5;
    private const int MINE = 6;
    private const int TOWERHEALTH = 7;

	private int money;
	public int startingMoney = 0;
	public float startingReward = 3000;
	private float reward = 3000;
    private int[] inventory = new int[8];
    private int[] itemPrices = new int[10];
    private GameObject[] inventoryButtons;

    private ButtonPlayerAction pistolButton;
    private ButtonPlayerAction rifleButton;
    private ButtonPlayerAction shotgunButton;
    private ButtonPlayerAction rpgButton;
    private ButtonPlayerAction grenadeLauncherButton;
    private ButtonPlayerAction turretButton;
    private ButtonPlayerAction mineButton;

    public Text moneyText;
	public Text rewardText;
    public TowerDownScript tower;

    public Pistol pistol;
    public AssaultRifle rifle;
    public Shotgun shotgun;
    public RocketLauncher rpg;
    public GrenadeLauncher grenadeLauncher;
    public Placeable turret;
    public Placeable mine;

    public void Start()
    {
		money = startingMoney;
        inventoryButtons = GameObject.FindGameObjectsWithTag("InventoryButton");
        Array.Sort(inventoryButtons, CompareObNames);

        itemPrices[RIFLE] = ConstantInventoryValues.RIFLE_INITIAL_COST;
        itemPrices[SHOTGUN] = ConstantInventoryValues.SHOTGUN_INITIAL_COST;
        itemPrices[RPG] = ConstantInventoryValues.RPG_INITIAL_COST;
        itemPrices[GRENADELAUNCHER] = ConstantInventoryValues.GRENADELAUNCHER_INITIAL_COST;
        itemPrices[TURRET] = ConstantInventoryValues.TURRET_COST;
        itemPrices[MINE] = ConstantInventoryValues.MINE_COST;
        itemPrices[TOWERHEALTH] = ConstantInventoryValues.TOWER_HEALTH_COST;
        refreshMoneyText();
		refreshRewardText();

        pistolButton = inventoryButtons[PISTOL].GetComponent<ButtonPlayerAction>();
        rifleButton = inventoryButtons[RIFLE].GetComponent<ButtonPlayerAction>();
        shotgunButton = inventoryButtons[SHOTGUN].GetComponent<ButtonPlayerAction>();
        rpgButton = inventoryButtons[RPG].GetComponent<ButtonPlayerAction>();
        grenadeLauncherButton = inventoryButtons[GRENADELAUNCHER].GetComponent<ButtonPlayerAction>();
        turretButton = inventoryButtons[TURRET].GetComponent<ButtonPlayerAction>();
        mineButton = inventoryButtons[MINE].GetComponent<ButtonPlayerAction>();
    }

	public void Update(){

        if (inventory[RIFLE] == 0)
        {
            rifleButton.interactable = false;
        }
        else
        {
            rifleButton.interactable = true;
        }

        if (inventory[SHOTGUN] == 0)
        {
            shotgunButton.interactable = false;
        }
        else
        {
            shotgunButton.interactable = true;
        }

        if (inventory[RPG] == 0)
        {
            rpgButton.interactable = false;
        }
        else
        {
            rpgButton.interactable = true;
        }

        if (inventory[GRENADELAUNCHER] == 0)
        {
            grenadeLauncherButton.interactable = false;
        }
        else
        {
            grenadeLauncherButton.interactable = true;
        }

        if (inventory[TURRET] == 0)
        {
            turretButton.interactable = false;
        }
        else
        {
            turretButton.interactable = true;
        }

        if (inventory[MINE] == 0)
        {
            mineButton.interactable = false;
        }
        else
        {
            mineButton.interactable = true;
        }

    }

    public void addItem(string item)
    {
        switch (item)
        {
            case ConstantInventoryValues.ASSAULT_RIFLE:
                if (Pay(itemPrices[RIFLE]))
                {
                    if (itemPrices[RIFLE] <= ConstantInventoryValues.RIFLE_INITIAL_COST)
                    {
                        itemPrices[RIFLE] = ConstantInventoryValues.RIFLE_AMMO_COST;
                    }
                    inventory[RIFLE] += ConstantInventoryValues.RIFLE_AMMO_TO_ADD;
                    rifle.addAmmo(ConstantInventoryValues.RIFLE_AMMO_TO_ADD);
                    rifleButton.RefreshText(inventory[RIFLE].ToString());
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
                    shotgunButton.RefreshText(inventory[SHOTGUN].ToString());
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
                    rpgButton.RefreshText(inventory[RPG].ToString());
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
                    grenadeLauncherButton.RefreshText(inventory[GRENADELAUNCHER].ToString());
                }
                break;
            case ConstantInventoryValues.TURRET:
                if (Pay(itemPrices[TURRET]))
                {
                    inventory[TURRET] += ConstantInventoryValues.TURRET_SUPPLY_TO_ADD;
                    turret.addAmmo(ConstantInventoryValues.TURRET_SUPPLY_TO_ADD);
                    turretButton.RefreshText(inventory[TURRET].ToString());
                }
                break;
            case ConstantInventoryValues.MINE:
                if (Pay(itemPrices[MINE]))
                {
                    inventory[MINE] += ConstantInventoryValues.MINE_SUPPLY_TO_ADD;
                    mine.addAmmo(ConstantInventoryValues.MINE_SUPPLY_TO_ADD);
                    mineButton.RefreshText(inventory[MINE].ToString());
                }
                break;
            case ConstantInventoryValues.TOWER_HEALTH:
                if (Pay(itemPrices[TOWERHEALTH]))
                {
                    tower.changeHealth(20);
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
        moneyText.text = "" + money + "$";
    }

	private void refreshRewardText()
	{
		rewardText.text = "" + Mathf.Floor(reward).ToString() + "$";
	}

    public int getPrice(string item)
    {
        switch (item)
        {
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
            default:
                return 0;
        }
    }

    public void useItem(string item)
    {
        switch (item)
        {
            case "Pistol":
                break;
            case "Rifle":
                if (inventory[RIFLE] > 0)
                {
                    inventory[RIFLE] = inventory[RIFLE] - 1;
                    rifleButton.RefreshText(inventory[RIFLE].ToString());
                }
                break;
            case "Shotgun":
                if (inventory[SHOTGUN] > 0)
                {
                    inventory[SHOTGUN] = inventory[SHOTGUN] - 1;
                    shotgunButton.GetComponent<ButtonPlayerAction>().RefreshText(inventory[SHOTGUN].ToString());
                }
                break;
            case "RPG":
                if (inventory[RPG] > 0)
                {
                    inventory[RPG] = inventory[RPG] - 1;
                    rpgButton.RefreshText(inventory[RPG].ToString());
                }
                break;
            case "GrenadeLauncher":
                if (inventory[GRENADELAUNCHER] > 0)
                {
                    inventory[GRENADELAUNCHER] = inventory[GRENADELAUNCHER] - 1;
                    grenadeLauncherButton.RefreshText(inventory[GRENADELAUNCHER].ToString());
                }
                
                break;
            case "Turret":
                if (inventory[TURRET] > 0)
                {
                    inventory[TURRET] = inventory[TURRET] - 1;
                    turretButton.RefreshText(inventory[TURRET].ToString());
                }
                break;
            case "Mine":
                if (inventory[MINE] > 0)
                {
                    inventory[MINE] = inventory[MINE] - 1;
                    mineButton.RefreshText(inventory[MINE].ToString());
                }
                break;
            default:
                break;
        }
    }

	public void setMoney(int money){

		this.money = money;
	}

	public int getMoney(){

		return money;

	}

	public void Penalize (){


		reward = Mathf.Max(reward - 200 * Time.deltaTime,0);
		refreshRewardText();
	}

	public void AddWaveMoney(){
		money = money + (int)Mathf.Floor(reward);
		reward = 3000;
		refreshRewardText();
		refreshMoneyText();
	}
}
