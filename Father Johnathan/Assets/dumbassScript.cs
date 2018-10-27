using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dumbassScript : MonoBehaviour {

    public GameObject doors;
    Animator anim;

	// Use this for initialization
	void Start () {
        anim = doors.GetComponent<Animator>();
        anim.SetTrigger("Toggle");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
