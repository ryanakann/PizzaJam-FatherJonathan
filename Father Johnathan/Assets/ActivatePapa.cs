using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePapa : MonoBehaviour {

    public GameObject papa;
    public bool activeOnEnterScene = false;

    private void Start () {
        if (activeOnEnterScene) {
            papa.GetComponent<FollowPlayer>().SwitchState(AIState.wandering);
        }
    }

    private void OnTriggerEnter (Collider other) {
        if (other.CompareTag("Player")) {
            papa.SetActive(true);
            papa.GetComponent<FollowPlayer>().SwitchState(AIState.wandering);
        }
    }
}
