using UnityEngine;
using System.Collections;

public class blood : MonoBehaviour {

	private AudioSource source;
	public AudioClip explosionSound;

	void Start(){
		source = GetComponent<AudioSource>();
	}
	// Update is called once per frame
	void Update () {
		source.PlayOneShot(explosionSound, 1F);
		Destroy(gameObject,5f);
	}
}
