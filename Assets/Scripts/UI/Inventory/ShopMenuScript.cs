using UnityEngine;
using System.Collections;

public class ShopMenuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OpenShop()
    {
        this.transform.position = new Vector3(0f, transform.position.y, 0f);
    }
}
