using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Interactor : MonoBehaviour {

    public TextMeshProUGUI text;

    Transform cam;
    Ray ray;
    RaycastHit hit;

	// Use this for initialization
	void Start () {
        cam = Camera.main.transform;

        if (text) {
            text.SetText("");
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (!text) return;
        ray = new Ray(cam.position, cam.forward);
        if (Physics.Raycast(ray, out hit, 2f)) {
            //print("Hit: " + hit.transform.name);
            Interactable thing;
            if (thing = hit.transform.root.GetComponent<Interactable>()) {
                text.SetText("press 'e' to " + thing.interactMessage + " " + thing.name);
                if (Input.GetKeyDown(KeyCode.E)) {
                    hit.transform.root.GetComponent<Interactable>().Interact();
                }
            } else {
                text.SetText("");
            }
        } else {
            text.SetText("");
        }
	}
}
