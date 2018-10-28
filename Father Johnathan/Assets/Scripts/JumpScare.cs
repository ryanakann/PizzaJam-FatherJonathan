using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScare : MonoBehaviour {

    public GameObject image;

	// Use this for initialization
	void Start () {
        EventManager.StartListening(EventType.PlayerDeath, Scare);
	}
	
    void Scare () {
        image.SetActive(true);
        Invoke("Unscare", 1.5f);
    }

    void Unscare () { 
        image.SetActive(false);
    }
}
