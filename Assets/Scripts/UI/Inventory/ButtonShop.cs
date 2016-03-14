using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonShop : MonoBehaviour {

    public void TogglePanel(GameObject panel)
    {
        panel.SetActive(true);
    }

    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
    }
}
