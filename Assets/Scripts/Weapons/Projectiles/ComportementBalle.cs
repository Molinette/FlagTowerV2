using UnityEngine;
using System.Collections;

public class ComportementBalle : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject, 2);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
		if (coll.gameObject.tag == "Enemy") {
			Enemy currentEnemy = coll.GetComponent<Runner> ();
			if (currentEnemy is Runner) {
				currentEnemy.Damage (20f);
			}
			Destroy (gameObject);
		} 
    }

}