using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyScript : MonoBehaviour {
    public Slider enemyHealthSlider;
    private int startingHealth;

    // Use this for initialization
    void Start () {
        startingHealth = 100;
        enemyHealthSlider.value = startingHealth;
    }

    // Update is called once per frame
    void Update () {
	
	}
}
