using UnityEngine;
using System.Collections;

public class WeaponSwitching : MonoBehaviour {

	public GameObject pistol;
	public GameObject shotgun;
	public GameObject assaultRifle;
	public GameObject grenadeLauncher;
	public GameObject rocketLauncher;
	public GameObject mine;
	public GameObject turret;

	void Start () {

		resetWeapons();
		pistol.SetActive (true);
	}

	void Update () {

		checkWeapons ();
	}
		
	void resetWeapons(){
	
		pistol.SetActive (false);
		shotgun.SetActive (false);
		assaultRifle.SetActive (false);
		grenadeLauncher.SetActive (false);
		rocketLauncher.SetActive (false);
		mine.SetActive (false);
		turret.SetActive (false);
	}
		
	void checkWeapons(){

		if (Input.GetKeyDown ("1")) {
			resetWeapons();
			pistol.SetActive (true);
		}

		else if (Input.GetKeyDown ("2")) {
			resetWeapons();
			assaultRifle.SetActive (true);
		}

		else if (Input.GetKeyDown ("3")) {
			resetWeapons();
			shotgun.SetActive (true);
		}

		else if (Input.GetKeyDown ("4")) {
			resetWeapons();
			grenadeLauncher.SetActive (true);
		}

		else if (Input.GetKeyDown ("5")) {
			resetWeapons();
			rocketLauncher.SetActive (true);
		}

		else if (Input.GetKeyDown ("6")) {
			resetWeapons();
			mine.SetActive (true);
		}

		else if (Input.GetKeyDown ("7")) {
			resetWeapons();
			turret.SetActive (true);
		}
	}
}
