using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamCheck : MonoBehaviour {

    public Transform boi;
    bool played = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (boi.position.z < -40f && !played) {
            GetComponent<AudioSource>().Play();
            played = true;
        }
	}
}
