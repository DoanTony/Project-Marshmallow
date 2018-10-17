using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventTrigger : MonoBehaviour {

    public UnityEvent eventStart;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            eventStart.Invoke();
            Destroy(this.gameObject);
        }
    }
}
