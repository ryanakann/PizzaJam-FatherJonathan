using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveBreadstick : MonoBehaviour {

    public GameObject breadstick;

	// Use this for initialization
	void Start () {
        EventManager.StartListening(EventType.ObtainCheese, Give);
	}
	
    void Give () {
        Invoke("Delay", 2f);
    }

    void Delay () {
        GameObject player = GameObject.FindWithTag("Player");
        player.GetComponent<Player>().hasBreadstick = true;
        GameObject b = Instantiate<GameObject>(breadstick, player.transform.position, Quaternion.identity);
        b.transform.SetParent(player.transform);
        b.transform.localPosition = new Vector3(0f, 0f, 1f);

        GameObject.Find("Father Jonathan").GetComponent<FollowPlayer>().SwitchState(AIState.fleeing);
    }
}
