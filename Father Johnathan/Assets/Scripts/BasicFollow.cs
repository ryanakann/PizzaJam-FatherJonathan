using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicFollow : MonoBehaviour {

    public float speed = 3f;
    Transform target;

	// Use this for initialization
	void Start () {
        target = GameObject.FindWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate((target.position - transform.position).normalized * speed * Time.deltaTime);
	}
}
