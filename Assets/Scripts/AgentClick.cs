using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentClick : MonoBehaviour {
    public Transform target;
    private UnityEngine.AI.NavMeshAgent agent;

    void Start() {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
                RaycastHit hit;
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100)) {
                    target.position = hit.point;
                }
            }
        agent.destination = target.position;
    }
}