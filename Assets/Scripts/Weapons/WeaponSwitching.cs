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

    public void usePistol(){
        resetWeapons();
        pistol.SetActive(true);
    }

    public void useKatana()
    {
        resetWeapons();
        //Missing Katana
    }

    public void useAssaultRifle()
    {
        resetWeapons();
        assaultRifle.SetActive(true);
    }

    public void useShotgun()
    {
        resetWeapons();
        shotgun.SetActive(true);
    }

    public void useGrenadeLauncher()
    {
        resetWeapons();
        grenadeLauncher.SetActive(true);
    }

    public void useRocketLauncher()
    {
        resetWeapons();
        rocketLauncher.SetActive(true);
    }

    public void useMine()
    {
        resetWeapons();
        mine.SetActive(true);
    }

    public void useTurret()
    {
        resetWeapons();
        turret.SetActive(true);
    }

    void checkWeapons(){

		if (Input.GetKeyDown ("1")) {
			resetWeapons();
			pistol.SetActive (true);
		}

		else if (Input.GetKeyDown ("3")) {
			resetWeapons();
			assaultRifle.SetActive (true);
		}

		else if (Input.GetKeyDown ("4")) {
			resetWeapons();
			shotgun.SetActive (true);
		}

        else if (Input.GetKeyDown("5"))
        {
            resetWeapons();
            rocketLauncher.SetActive(true);
        }

        else if (Input.GetKeyDown ("6")) {
			resetWeapons();
			grenadeLauncher.SetActive (true);
		}

		else if (Input.GetKeyDown ("7")) {
			resetWeapons();
			mine.SetActive (true);
		}

		else if (Input.GetKeyDown ("8")) {
			resetWeapons();
			turret.SetActive (true);
		}
	}
}
