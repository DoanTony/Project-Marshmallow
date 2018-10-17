using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {


    public bool allowDamping;
    public float dampingSpeed = 1;
    public Transform targetToFollow;


	void Update () {
        FollowTarget();
	}

    private void FollowTarget()
    {
        if (allowDamping)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, targetToFollow.position, dampingSpeed * Time.deltaTime);
        }
        else
        {
            this.transform.position = targetToFollow.position;  
        }
    }
}
