using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(Elemental))]
public class Projectile : MonoBehaviour
{
    Elemental elemental;
    public Vector3 pos;
    public float movementSpeed = 10.0f;
    public float lifeSpan = 4.0f;
    public bool isEnemyProjectile = false;

    private void Awake()
    {
        this.tag = "Projectile";
        elemental = this.GetComponent<Elemental>();
    }

    private void Start()
    {
        StartCoroutine(DelayDestroySelf());
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        this.transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isEnemyProjectile)
        {
            if (other.transform.tag != "Player")
            {
                if (other.GetComponent<ITakeDamage>() != null)
                {
                    other.GetComponent<ITakeDamage>().TakeDamage(elemental.element);
                    Destroy(this.gameObject);
                }
            }
        }
        else
        {
            if (other.transform.tag == "Player")
            {
                other.GetComponent<ITakeDamage>().TakeDamage(elemental.element);
                Destroy(this.gameObject);
            }
        }
    }

    IEnumerator DelayDestroySelf()
    {
        yield return new WaitForSeconds(lifeSpan);
        Destroy(this.gameObject);
    }
}
