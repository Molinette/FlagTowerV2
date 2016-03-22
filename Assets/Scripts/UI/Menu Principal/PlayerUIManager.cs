using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerUIManager : MonoBehaviour {

    public Text LevelsText;

    private int playerLevel;
    
    private int katanaLevel;

    private int pistolAmmo;
    private int rifleLevel;
    private int shotgunLevel;

    private int rpgLevel;
    private int grenadeLevel;
    private int grenadeLauncherLevel;
    private int mineAmmo;

    public void Start()
    {
        playerLevel = 1;

        katanaLevel = 1;
        pistolAmmo = 1;
        rifleLevel = 1;
        shotgunLevel = 1;
        rpgLevel = 1;
        grenadeLevel = 1;
        grenadeLauncherLevel = 1;
        mineAmmo = 1;
    }

    public void Update()
    {
        LevelsText.text = "Player Level: " + playerLevel + "\n" + "\n"
            + "Katana Level: " + katanaLevel + "\n" + "\n"
            + "Pistol Ammo: " + pistolAmmo + "\n" + "\n"
            + "Mines  Level: " + mineAmmo;
    }

    public void RaiseLevel(string upgrade)
    {
        switch (upgrade)
        {
            case "Katana":
                katanaLevel++;
                break;
            case "Pistol":
                pistolAmmo++;
                break;
            case "Rifle":
                rifleLevel++;
                break;
            case "Shotgun":
                shotgunLevel++;
                break;
            case "RPG":
                rpgLevel++;
                break;
            case "Grenade":
                grenadeLevel++;
                break;
            case "GrenadeLauncher":
                grenadeLauncherLevel++;
                break;
            case "Mine":
                mineAmmo++;
                //
                break;
            default:
                break;
        }
    }

}