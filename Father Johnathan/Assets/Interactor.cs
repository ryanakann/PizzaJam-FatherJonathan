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
        text.SetText("");
	}
	
	// Update is called once per frame
	void Update () {
        ray = new Ray(cam.position, cam.forward);
        if (Physics.Raycast(ray, out hit, 2f)) {
            //print("Hit: " + hit.transform.name);
            if (hit.transform.GetComponent<Interactable>()) {
                text.SetText("press 'e' to interact with " + hit.transform.name);
                if (Input.GetKeyDown(KeyCode.E)) {
                    hit.transform.GetComponent<Interactable>().Interact();
                }
            } else {
                text.SetText("");
            }
        } else {
            text.SetText("");
        }
	}
}
