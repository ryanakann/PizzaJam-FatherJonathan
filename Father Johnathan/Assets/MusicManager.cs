using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    public static MusicManager instance;

	// Use this for initialization
	void Awake () {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(this);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
