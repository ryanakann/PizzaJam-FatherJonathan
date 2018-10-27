using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour {

    private Transform cam;

	// Use this for initialization
	void Start () {
        cam = Camera.main.transform;
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(new Vector3(cam.position.x, transform.position.y, cam.position.z), Vector3.up);
	}
}
