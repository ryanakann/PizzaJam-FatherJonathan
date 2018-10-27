using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(BoxCollider))]
public class DoorTrigger : MonoBehaviour {

    public Animator doorAnimator;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Close Door
    private void OnTriggerExit(Collider other)
    {
        doorAnimator.SetTrigger("Toggle");
    }

    //Open Door
    private void OnTriggerEnter(Collider other)
    {
        doorAnimator.SetTrigger("Toggle");
    }
}
