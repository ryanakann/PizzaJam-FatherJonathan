using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : Interactable {

    public Animator doorAnimator;

    public override void Interact() {
        print("OpenyClozy!");
        if (!doorAnimator)
            doorAnimator = GetComponent<Animator>();

        if (doorAnimator) {
            doorAnimator.SetTrigger("Toggle");
        }
    }
}
