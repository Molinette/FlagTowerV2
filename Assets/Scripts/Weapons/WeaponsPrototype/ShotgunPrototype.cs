using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShotgunPrototype : MonoBehaviour {

	public float bulletSpeed;
	public Transform firingPosition;
	public GameObject bullet;
	GameObject bulletInstance;
	public int bulletCount;
	public float coveringAngle;
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
		float shootingDirectionAngle = VectorAngle(shootingDirection);

		if (Input.GetMouseButtonDown(0))
		{
            source.PlayOneShot(shootSound, 1F);
            float angleIncrements = coveringAngle/(bulletCount-1);
			float startingAngle = shootingDirectionAngle + 360 + coveringAngle/2;

			for(int i = 0; i <= bulletCount-1; i++){
				//print(startingAngle - i*angleIncrements);
				Vector2 bulletDirection;
				bulletDirection.x = Mathf.Cos((startingAngle - i*angleIncrements)*Mathf.Deg2Rad);
				bulletDirection.y = Mathf.Sin((startingAngle - i*angleIncrements)*Mathf.Deg2Rad);

				//Instance the bullet and give it an initial speed in the direction of the mouse
				bulletInstance = (GameObject)Instantiate(bullet, firingPosition.position, firingPosition.rotation);
				bulletInstance.GetComponent<Rigidbody2D>().velocity = (bulletDirection.normalized * bulletSpeed);
			}

		}
	}

	float VectorAngle(Vector2 vector){
		float angle = 0f;
		if(vector.x != 0f){
			if(vector.x > 0f){
				angle = 360f + Mathf.Atan(vector.y/vector.x) * Mathf.Rad2Deg;
			} 
			else if(vector.x < 0f){
				angle = 180f + Mathf.Atan(vector.y/vector.x) * Mathf.Rad2Deg;
			}
		}
		else if(vector.x == 0f){
			if(vector.y > 0f){
				angle = 90f;
			} else if(vector.y < 0f){
				angle = 275f;
			}
			else{
				angle = 0f;
			}
		}
		return angle;
	}
}
