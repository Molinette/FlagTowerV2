using UnityEngine;
using System.Collections;

public class MenuParticles : MonoBehaviour {
	public ParticleSystem particles1;
	public Color color1;
	public Color color2;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void MainParticles(int color){
		switch(color){
		case 1 :
			particles1.startColor = color1;
			break;
		case 2 : 
			particles1.startColor = color2;
			break;
		}
	}
}
