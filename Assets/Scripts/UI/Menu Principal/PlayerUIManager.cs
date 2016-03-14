using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerUIManager : MonoBehaviour {

    public Text LevelsText;

    private string[] PossibleUpgrades;

    private int playerLevel;
    private int meleeLevel;
    private int pistolLevel;
    private int rifleLevel;
    private int shotgunLevel;
    private int explosivesLevel;

    public void Start()
    {
        meleeLevel = 1;
        pistolLevel = 1;
        rifleLevel = 1;
        shotgunLevel = 1;
        explosivesLevel = 1;

        LevelsText.text = "Player Level: " + playerLevel + "\n"
            + "Melee Level: " + meleeLevel + "\n"
            + "Pistol Level: " + pistolLevel + "\n"
            + "Rifle Level: " + rifleLevel + "\n"
            + "Shotgun Level: " + shotgunLevel + "\n"
            + "Explosives Level: " + explosivesLevel;

    }

    public void RaiseLevel(string upgrade)
    {

    }

    private void SetPossibleUpgrades()
    {

    }
}
