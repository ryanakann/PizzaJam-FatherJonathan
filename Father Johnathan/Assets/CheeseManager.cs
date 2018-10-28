using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Cheese[] cheeses = GetComponentsInChildren<Cheese>();

        int leng = cheeses.Length;

        int theCheese = Random.Range(0, leng);

        for(int i = 0; i < leng; i++) {
            if (i != theCheese) {
                Destroy(cheeses[i].gameObject);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
