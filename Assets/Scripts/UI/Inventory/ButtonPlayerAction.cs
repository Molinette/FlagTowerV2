using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonPlayerAction : MonoBehaviour {

    private string item;
    private int numItems;

    private bool isActive;

    public Text buttonText;
    
    public void RefreshText(string text)
    {
        buttonText.text = text;
    }
}
