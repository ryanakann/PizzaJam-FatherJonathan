using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComeOnIn : MonoBehaviour {

	// Use this for initialization
	void Start () {
        EventManager.StartListening(EventType.ObtainCheese, IThinkYoullLikeIt);
	}
	
    void IThinkYoullLikeIt () {
        Invoke("Wait", 1.5f);
    }

    void Wait () {
        GetComponent<AudioSource>().Play();
    }
}
