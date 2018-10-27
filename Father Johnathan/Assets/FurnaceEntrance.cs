using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnaceEntrance : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.parent.Find("Particle System").GetChild(0).gameObject.SetActive(false);

        EventManager.StartListening(EventType.ObtainCheese, OpenFurnace);
	}
	
    void OpenFurnace () { 
        transform.parent.Find("Particle System").GetChild(0).gameObject.SetActive(true);
        transform.parent.Find("Particle System").GetChild(1).GetComponent<AudioSource>().Play();
        gameObject.SetActive(false);
    }
}
