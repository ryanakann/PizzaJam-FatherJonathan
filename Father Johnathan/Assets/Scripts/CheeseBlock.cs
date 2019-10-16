using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseBlock : MonoBehaviour {

	// Use this for initialization
	void Start () {
        EventManager.StartListening(EventType.ObtainCheese, Lit);
	}
	
    void Lit () {
        gameObject.SetActive(false);
    }
}
