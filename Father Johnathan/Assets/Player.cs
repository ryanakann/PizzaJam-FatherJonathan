using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public bool hasBreadstick = false;
    public bool isHiding = false;

    private void Start () {
        isHiding = false;
        EventManager.StartListening(EventType.EnterFurnace, Hide);
    }

    void Hide () {
        isHiding = true;
    }

    private void Update () {
        if (Input.GetKeyDown(KeyCode.H)) {
            isHiding = !isHiding;
        }
    }
}
