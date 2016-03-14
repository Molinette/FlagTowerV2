using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelManager : MonoBehaviour {

    private string[] possibleItems;
      

    public Text warningTextUpRight;
    public Text warningTextUpLeft;
    public Text warningTextDownRight;
    public Text warningTextDownLeft;

    public Text remainingHostilesText;

    public ButtonPlayerAction ButtonPlayerAction1;
    public Button ButtonPlayerAction2;
    public Button ButtonPlayerAction3;
    public Button ButtonPlayerAction4;
    public Button ButtonPlayerAction5;
    public Button ButtonPlayerAction6;

    public Button[] ArrayButtonPlayerAction;

    public Button ButtonShop;


    public int money;
    public Text MoneyText;

    private string itemShop;

    // Use this for initialization
    void Start () {
        possibleItems = new string[6];

        warningTextUpRight.text = "";
        warningTextUpLeft.text = "";
        warningTextDownRight.text = "";
        warningTextDownLeft.text = "";
        remainingHostilesText.text = "Hostiles left: ";


        for (int index = 0; index < ArrayButtonPlayerAction.Length; index++)
        {
        }
        
    }
	
	// Update is called once per frame
	void Update () {
        money = Mathf.Max(money, 0);
        MoneyText.text = money.ToString() + "$";
    }

    public void GetItem(string item)
    {
        itemShop = item;
    }

    public void Pay(int cost)
    {
        if (cost <= money){
            money = (money - cost);
            MoneyText.text = money.ToString();
            GiveItem(itemShop);
        }
        itemShop = "";
    }

    private void GiveItem(string item)
    {
        ButtonPlayerAction1.AcquireItem(item);
    }
}
