using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyPatrol : MonoBehaviour {

    public float detectionRadius = 5f;
    public List<Transform> waypoints;
    public Collider[] hitColliders;
    public float delayBetweenShots = 2.0f;

    private NavMeshAgent agent;
    private int index = 0 ;
    private Transform target = null;

    private bool isMoving = false;
    private bool isTargetInRange = false;
    private bool canShoot = true;

    private Enemy enemy;

    void Start () {
        agent = GetComponent<NavMeshAgent>();
        enemy = GetComponent<Enemy>();
        canShoot = true;
	}
	
	void Update () {
        if (!isMoving && !isTargetInRange)
        {
            Move();
        }
        else if (isTargetInRange)
        {
            AttackTarget();
        }
        else
        {
            CheckDestination();
        }

        CheckForTarget();
	}

    private void AttackTarget()
    {
        this.transform.LookAt(target.position);
        Quaternion q = transform.rotation;
        q.eulerAngles = new Vector3(0, q.eulerAngles.y, 0);
        transform.rotation = q;
        if (canShoot)
        {
            GameObject projectile = Instantiate(enemy.type.enemyProjectilePrefab, this.transform.position, this.transform.rotation);
            canShoot = false;
            StartCoroutine(DelayShootEnable());
        }
    }

    IEnumerator DelayShootEnable()
    {
        yield return new WaitForSeconds(delayBetweenShots);
        canShoot = true;
    }

    private void CheckForTarget()
    {
        LayerMask playerMask = 1 << LayerMask.NameToLayer("Player");
        hitColliders = Physics.OverlapSphere(this.transform.position, detectionRadius, playerMask);
        if(hitColliders.Length > 0)
        {
            isTargetInRange = true;
            isMoving = false;
            StopMoving();
            target = hitColliders[0].transform;
        }
        else
        {
            isTargetInRange = false;
            target = null;
        }
    }

    private void CheckDestination()
    {
        float distance = Vector3.Distance(this.transform.position, waypoints[index].position);
        if(distance < 1)
        {
            index++;
            isMoving = false;
        }
    }

    private void Move()
    {
        if(index > waypoints.Count - 1)
        {
            index = 0; // reset counter
        }
        if (waypoints.Count > 0)
        {
            if (waypoints[index] != null)
            {
                agent.isStopped = false;
                agent.SetDestination(waypoints[index].position);
                isMoving = true;
            }
        }
    }

    private void StopMoving()
    {
        agent.isStopped = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, detectionRadius);
    }
}
