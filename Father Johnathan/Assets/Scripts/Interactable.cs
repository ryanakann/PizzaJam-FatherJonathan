using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

    public string interactMessage = "interact with";
    public new string name = "Cheese";

    public virtual void Interact () {
        
    }
}
