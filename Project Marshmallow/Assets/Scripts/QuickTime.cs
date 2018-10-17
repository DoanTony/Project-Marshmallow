using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class QuickTime : MonoBehaviour {

    public float slowDownFactor = 0.05f;
    public float slowDownLength = 2f;

    public UnityEvent eventStart;
    public UnityEvent eventEnd;
    private bool trapActive;
    private bool isPlayerSafe = false;

	void Update () {
        if (trapActive)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                isPlayerSafe = true;
                isPlayerSafe = true;
            }
        }
	}

    IEnumerator DoSlowMotion(Player _player)
    {
        Time.timeScale = slowDownFactor;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
        yield return new WaitForSeconds(slowDownLength);
        if (!isPlayerSafe)
        {
            _player.KillPlayer();
        }
        Time.timeScale = 1;
        Time.fixedDeltaTime = 1;
        eventEnd.Invoke();
        if (isPlayerSafe)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            trapActive = true;
            StartCoroutine(DoSlowMotion(other.GetComponent<Player>()));
            eventStart.Invoke();
        }
    }
}
