using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonPlayerAction : MonoBehaviour {

    private string item;
    private int numItems;

    public Text buttonText;

	public void AcquireItem(string item){
        if (this.item != item)
        {
            this.item = item;
        }
        numItems++;
        refreshText();
    }

    public void UseItem()
    {
        numItems--;
        refreshText();
    }

    private void refreshText()
    {
        if(numItems <= 0)
        {
            item = "";
            numItems = 0;
            buttonText.text = "";
        }
        else
        {
            buttonText.text = numItems + " " + this.item;
        }
    }
}
