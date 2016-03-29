using UnityEngine;
using System.Collections;

public class GrenadeLuncherPrototype : MonoBehaviour {

	public float maxThrowingForce;
	public float forceIncrement;
	public Transform firingPosition;
	public GameObject bullet;
	private float currentThrowingForce;
	GameObject bulletInstance;
    private AudioSource source;
    public AudioClip shootSound;

    // Use this for initialization
    void Awake()
    {

        source = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update () {
		Vector2 shootingDirection;
		Vector3 mousePosition;

		mousePosition = Input.mousePosition;
		mousePosition.z = -Camera.main.transform.position.z;
		shootingDirection = (Vector2)Camera.main.ScreenToWorldPoint (mousePosition) - (Vector2)transform.position;

		if (Input.GetMouseButtonDown(0)){
			currentThrowingForce = 0;
		}

		if(Input.GetMouseButton(0)){
			currentThrowingForce = Mathf.Min(currentThrowingForce + forceIncrement*Time.deltaTime, maxThrowingForce); 
		}

		if(Input.GetMouseButtonUp(0)){

            source.PlayOneShot(shootSound, 1F);
            //Instance the bullet and give it an initial speed in the direction of the mouse
            bulletInstance = (GameObject)Instantiate(bullet, firingPosition.position, firingPosition.rotation);
			bulletInstance.GetComponent<Rigidbody2D>().AddForce(shootingDirection.normalized * currentThrowingForce,ForceMode2D.Impulse);
		}
	}

}
