using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnaceTrigger : MonoBehaviour {

    private void OnTriggerEnter (Collider other) {
        if (other.CompareTag("Player")) {
            UILevelTransition.instance.OnTransition();
        }
    }
}
