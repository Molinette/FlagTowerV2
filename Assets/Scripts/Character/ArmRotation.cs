using UnityEngine;
using System.Collections;

public class ArmRotation : MonoBehaviour {
	//If the sprite origin is not left (0 degrees from horizontal), we substract the starting angle
	public float startingAngle;

    void Start()
    {
		
    }

    void Update()
    {
        Vector3 direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
		float rotationZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - startingAngle;
		transform.eulerAngles = new Vector3(0, 0, rotationZ);
    }
}