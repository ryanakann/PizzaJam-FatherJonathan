using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasScript : MonoBehaviour {

    public static CanvasScript instance;

	// Use this for initialization
	void Start () {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
