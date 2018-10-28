using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicScript : MonoBehaviour {

    public AudioSource player;
    private static bool created = false;

    private void Awake()
    {
        if(!created) {
            created = true;
            DontDestroyOnLoad(this.gameObject);
        }

    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
