using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour {

    NavMeshAgent agent;
	void Start () {
        agent = GetComponent<NavMeshAgent>();
	}
	
	void Update () {
        if (Input.GetMouseButton(1))
        {
            if (agent.isStopped)
            {
                agent.isStopped = false;
            }
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            LayerMask floorLayerMask = 1 << LayerMask.NameToLayer("Floor");

            if (Physics.Raycast(ray, out hit, floorLayerMask))
            {
                agent.SetDestination(hit.point);
            }
        }

        Rotate();
	}

    private void Rotate()
    {
        Plane zeroPlane = new Plane(Vector3.up, new Vector3(0,2.0f,0));
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float distance;
        if (zeroPlane.Raycast(ray, out distance))
        {
            Vector3 outputPosition = ray.origin + ray.direction * distance;
            this.transform.LookAt(outputPosition);
            Quaternion q = transform.rotation;
            q.eulerAngles = new Vector3(0, q.eulerAngles.y, 0);
            transform.rotation = q;
        }
    }

    public void Stop()
    {
        agent.isStopped = true;
    }
}
