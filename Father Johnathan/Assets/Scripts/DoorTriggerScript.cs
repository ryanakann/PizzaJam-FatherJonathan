using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerScript : MonoBehaviour {

    public Animator doorAnimator;

	// Use this for initialization
	void Start () {
        if (!doorAnimator) {
            doorAnimator = GetComponent<Animator>();
        }

        EventManager.StartListening(EventType.ObtainCheese, Toggle);
	}
	
    void Toggle() {
        if (doorAnimator) {
            doorAnimator.SetTrigger("Toggle");
        }
    }
}