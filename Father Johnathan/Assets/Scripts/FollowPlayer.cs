using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour {

    NavMeshAgent agent;
    Transform target;

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, target.position, out hit)) {
            if (hit.transform.tag == "Player") {
                //agent.speed = 3f;
            } else {
                //agent.speed = 6f;
            }
        }
        agent.SetDestination(target.position);
        //agent.CalculatePath(target.position, 
	}
}
