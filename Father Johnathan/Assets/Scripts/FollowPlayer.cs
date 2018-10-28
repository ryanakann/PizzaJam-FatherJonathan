using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum AIState {
    wandering,
    following,
    done,
    fleeing,
}

public class FollowPlayer : MonoBehaviour {

    NavMeshAgent agent;
    Transform player;
    Transform nodes;

    [SerializeField] AIState state;

    Vector3 target;
    Vector3 hitPoint;

    bool hitPlayer;
    bool stopFollowing;
    float secondsSincePlayerSeen;

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player").transform;

        if (GameObject.Find("Nodes")) {
            nodes = GameObject.Find("Nodes").transform;
        } else {
            state = AIState.done;
        }

        hitPlayer = false;
        secondsSincePlayerSeen = 0f;
	}

    void SwitchState (AIState newState) {
        state = newState;

        switch (state) {
            default:
                break;
            case AIState.wandering:
                target = nodes.GetChild(Random.Range(0, nodes.childCount)).position;
                target.y = transform.position.y;
                break;

            case AIState.done:
                transform.position = new Vector3(0f, -100f, 0f);
                break;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (state == AIState.done) return;

        if (player.GetComponent<Player>().hasBreadstick) {
            SwitchState(AIState.fleeing);
        } else if (player.GetComponent<Player>().isHiding) {
            if (state != AIState.wandering) {
                SwitchState(AIState.wandering);
            }
        } else {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, player.position - transform.position, out hit)) {
                hitPoint = hit.point;
                if (hit.transform.tag == "Player") {
                    SwitchState(AIState.following);
                    hitPlayer = true;
                } else {
                    hitPlayer = false;
                }
            } else {
                hitPlayer = false;
            }

            if (!hitPlayer) {
                if (secondsSincePlayerSeen > 3f) {
                    if (!stopFollowing) {
                        if (state == AIState.following) {
                            SwitchState(AIState.wandering);
                        }
                    }
                } else {
                    secondsSincePlayerSeen += Time.deltaTime;
                }
            } else {
                secondsSincePlayerSeen = 0f;
            }
        }


        switch (state) {
            default:
                break;
            case AIState.following:
                target = player.position;

                if ((target - transform.position).sqrMagnitude < 2f) {
                    EventManager.TriggerEvent(EventType.PlayerDeath);
                    SwitchState(AIState.done);
                }
                break;

            case AIState.wandering:
                if ((new Vector2(transform.position.x, transform.position.z) - new Vector2(target.x, target.z)).sqrMagnitude < 2f) {
                    SwitchState(AIState.wandering);
                }
                break;

            case AIState.fleeing:
                target = transform.position + (transform.position - player.position).normalized * 10f;

                if ((target - transform.position).sqrMagnitude < 2f) {
                    EventManager.TriggerEvent(EventType.EndGame);
                    SwitchState(AIState.done);
                }
                break;
        }

        agent.SetDestination(target);
	}

    private void OnDrawGizmos () {
        #if UNITY_EDITOR
        return;
        #endif

        Gizmos.color = Color.green;
        Gizmos.DrawSphere(target, 5f);
        if (hitPoint != Vector3.zero) {
            Gizmos.DrawRay(transform.position, hitPoint - transform.position);
        }
    }

    //private void OnCollisionEnter (Collision collision) {
    //    print("HIT");
    //    if (collision.transform.CompareTag("Player")) {
    //        print("Collision");

    //    }
    //}
}
