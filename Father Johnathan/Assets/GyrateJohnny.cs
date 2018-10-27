using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyrateJohnny : MonoBehaviour {

    Vector3 initial;

	// Use this for initialization
	void Start () {
        initial = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		//transform.position = new Vector3
        transform.position = transform.position + Random.insideUnitSphere * 2f;
	}
}
