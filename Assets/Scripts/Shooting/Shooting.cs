using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {

	public float bulletSpeed;
	public Transform firingPosition;
	public GameObject bullet;
	GameObject bulletInstance;
    private AudioSource source;
    public AudioClip shootSound;

	// Use this for initialization
	void Awake () {

        source = GetComponent<AudioSource>();

	}

	// Update is called once per frame
	void Update () {
		Vector2 shootingDirection;
		Vector3 mousePosition;

		mousePosition = Input.mousePosition;
		mousePosition.z = -Camera.main.transform.position.z;
		shootingDirection = (Vector2)Camera.main.ScreenToWorldPoint (mousePosition) - (Vector2)transform.position;

		if (Input.GetMouseButtonDown(0))
		{
            source.PlayOneShot(shootSound, 1F);
			//Instance the bullet and give it an initial speed in the direction of the mouse
			bulletInstance = (GameObject)Instantiate(bullet, firingPosition.position, firingPosition.rotation);
			bulletInstance.GetComponent<Rigidbody2D>().velocity = (shootingDirection.normalized * bulletSpeed);

		}
	}
}
