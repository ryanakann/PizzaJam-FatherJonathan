using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PapaChaseTrigger : MonoBehaviour {

    public GameObject oldPapa;
    public GameObject newPapa;

    bool triggered = false;

    FollowPlayer papaFollow;

	// Use this for initialization
	void Start () {
        if (newPapa) {
            papaFollow = newPapa.GetComponent<FollowPlayer>();
            papaFollow.SwitchState(AIState.stop);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other) {
        AudioSource oldSource = oldPapa.GetComponent<AudioSource>();
        oldSource.mute = true;
    }

    private void OnTriggerExit(Collider other) {

        // EventManager.TriggerEvent("PapaChase");

        if (papaFollow && !triggered) {
            papaFollow.SwitchState(AIState.following);
            triggered = true;
        }

    }

}
