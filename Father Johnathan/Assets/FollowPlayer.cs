﻿using System.Collections;
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

        print("Lit");
	}
	
	// Update is called once per frame
	void Update () {
        agent.SetDestination(target.position);
        //agent.CalculatePath(target.position, 
	}
}
