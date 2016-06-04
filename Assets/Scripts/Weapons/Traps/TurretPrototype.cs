using UnityEngine;
using System.Collections;

public class TurretPrototype : MonoBehaviour {

	public float damage;
    public float bulletSpeed;
    public float firingDelay;
    public Transform firingPosition;
    public GameObject bullet;
    GameObject bulletInstance;
    Vector2 shootingDirection;
    Transform target;

    private float fireTime;

    // Use this for initialization
    void Start () {
        fireTime = Time.time + firingDelay;
        if (transform.position.x < 1)
        {
            shootingDirection = Vector2.left;
        }
        else
        {
            shootingDirection = Vector2.right;
        }
	}
	
	// Update is called once per frame
	void Update () {

        if (Time.time > fireTime)
        {
            //Instance the bullet and give it an initial speed in the direction of the mouse
            bulletInstance = (GameObject)Instantiate(bullet, firingPosition.position, firingPosition.rotation);
            bulletInstance.GetComponent<Rigidbody2D>().velocity = (shootingDirection.normalized * bulletSpeed);
			bulletInstance.GetComponent<Bullet>().SetDamage(damage);
            fireTime = Time.time + firingDelay;
        }

       
    }
}
