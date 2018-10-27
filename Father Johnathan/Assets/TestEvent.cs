using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEvent : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //EventManager.StartListening("StringDisplay", StringEvent);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void StringEvent (string thing) {
        print("Event triggered: " + thing);
    }
}
