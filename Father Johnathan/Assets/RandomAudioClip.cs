using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAudioClip : MonoBehaviour {

    public AudioClip[] clips;
    private AudioSource source;

	// Use this for initialization
	void Start () {
        if (!(source = GetComponent<AudioSource>())) {
            source = gameObject.AddComponent<AudioSource>();
        }

        InvokeRepeating("Play", 5f, 10f);
	}

    void Play () {
        if (clips.Length > 0) {
            source.clip = clips[Random.Range(0, clips.Length)];
            source.pitch = Random.Range(0.8f, 1.0f);
            source.Play();
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
