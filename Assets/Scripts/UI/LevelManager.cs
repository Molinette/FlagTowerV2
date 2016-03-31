using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelManager : MonoBehaviour {      

    public Text warningTextUpRight;
    public Text warningTextUpLeft;
    public Text warningTextDownRight;
    public Text warningTextDownLeft;

    public Text remainingHostilesText;

    public PlayerUIManager playerUI;

    public int money;
    public Text MoneyText;

    private string itemShop;

    // Use this for initialization
    void Start () { 

        warningTextUpRight.text = "";
        warningTextUpLeft.text = "";
        warningTextDownRight.text = "";
        warningTextDownLeft.text = "";
        remainingHostilesText.text = "Hostiles left: ";

    }
	
	// Update is called once per frame
	void Update () {
        //money = Mathf.Max(money, 0);
        //MoneyText.text = money.ToString() + "$";
    }
    
}
