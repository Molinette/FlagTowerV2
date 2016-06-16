using UnityEngine;
using System.Collections;

public class AudioScript : MonoBehaviour {

   private AudioSource source;
    public AudioClip grenadeSound;
    // Use this for initialization
    void Start () {

        source = GetComponent<AudioSource>();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void PlayExplosionSound()
    {
        source.PlayOneShot(grenadeSound, 1F);

    }
}
