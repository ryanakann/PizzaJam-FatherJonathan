using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenLight : MonoBehaviour {

	// Use this for initialization
	void Start () {
        EventManager.StartListening(EventType.ObtainCheese, TurnOffLight);
	}
	
    void TurnOffLight () {
        GetComponent<Light>().intensity = 0;
    }
}
