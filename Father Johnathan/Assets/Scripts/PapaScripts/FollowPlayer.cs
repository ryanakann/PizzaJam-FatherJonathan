using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum AIState {
    wandering,
    following,
    done,
    fleeing,
    stop,
}

public class FollowPlayer : MonoBehaviour {

    NavMeshAgent agent;
    Transform player;
    Transform nodes;

    [SerializeField] AIState state;

    Vector3 target;
    Vector3 hitPoint;

    bool canKill = true;

    bool hitPlayer;
    bool stopFollowing;
    float secondsSincePlayerSeen;

    public float speed = 5f;

    public bool startOnAwake = false;

	// Use this for initialization
	void Awake () {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        player = GameObject.FindWithTag("Player").transform;

        if (GameObject.Find("Nodes")) {
            nodes = GameObject.Find("Nodes").transform;
        } else {
            state = AIState.done;
        }

        hitPlayer = false;
        secondsSincePlayerSeen = 0f;

        if (startOnAwake) {
            SwitchState(AIState.wandering);
        }
	}

    void Start () {
        EventManager.StartListening(EventType.EnterFurnace, ToggleCanKill);
    }

    public void SwitchState (AIState newState) {
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

    void ToggleCanKill() {
        canKill = !canKill;
    }

	// Update is called once per frame
	void Update () {
        if (state == AIState.done || state == AIState.stop) return;

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
                    agent.speed = speed;
                    hitPlayer = true;
                } else {
                    if ((transform.position - player.position).magnitude > 50f) {
                        agent.speed = speed * 3;
                    } else {
                        agent.speed = speed * 2;
                    }
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
                //print("Following");
                target = player.position;

                if (canKill && (target - transform.position).sqrMagnitude < 2f) {
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
                agent.speed = 5f;
                target = transform.position + (new Vector3(transform.position.x, 0f, transform.position.z) - new Vector3(player.position.x, 0f, player.position.z)).normalized * 1.5f;

                if ((target - transform.position).sqrMagnitude < 2f) {
                    EventManager.TriggerEvent(EventType.EndGame);
                    SwitchState(AIState.done);
                }
                break;
        }

        agent.SetDestination(target);
	}

    private void OnDrawGizmos () {
        //#if UNITY_EDITOR
        //return;
        //#endif

        Gizmos.color = Color.green;
        Gizmos.DrawSphere(target, 5f);
        if (hitPoint != Vector3.zero) {
            Gizmos.DrawRay(transform.position, hitPoint - transform.position);
        }
    }
 //               break;
 //           case AIState.following:
 //               target = player.position;

 //               if ((target - transform.position).sqrMagnitude < 2f) {
 //                   EventManager.TriggerEvent(EventType.PlayerDeath);
 //                   SwitchState(AIState.done);
 //               }
 //               break;

 //           case AIState.wandering:
 //               if ((new Vector2(transform.position.x, transform.position.z) - new Vector2(target.x, target.z)).sqrMagnitude < 2f) {
 //                   SwitchState(AIState.wandering);
 //               }
 //               break;

 //           case AIState.fleeing:
 //               target = transform.position + (transform.position - player.position).normalized * 10f;

 //               if ((target - transform.position).sqrMagnitude < 2f) {
 //                   EventManager.TriggerEvent(EventType.EndGame);
 //                   SwitchState(AIState.done);
 //               }
 //               break;
 //       }

 //       agent.SetDestination(target);
	//}

    //private void OnDrawGizmos () {
    //    Gizmos.color = Color.green;
    //    Gizmos.DrawSphere(target, 5f);
    //    if (hitPoint != Vector3.zero) {
    //        Gizmos.DrawRay(transform.position, hitPoint - transform.position);

    //    }
    //}

    //private void OnCollisionEnter (Collision collision) {
    //    print("HIT");
    //    if (collision.transform.CompareTag("Player")) {
    //        print("Collision");

    //    }
    //}
}
