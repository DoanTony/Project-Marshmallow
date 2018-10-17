using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour, ITakeDamage{

    public PlayerScriptableObject playerObject;
    public Transform startZone;
    private PlayerController pc;

    void Awake()
    {
        pc = GetComponent<PlayerController>();
    }

    public void TakeDamage(ElementsScriptableObject _element)
    {
        playerObject.ReduceHealth();
        if (playerObject.currentHealth <= 0)
        {
            KillPlayer();
        }
    }

    public void KillPlayer()
    {
        StartCoroutine(DelayKill());
    }

    private IEnumerator DelayKill()
    {
        yield return new WaitForSeconds(1f);
        pc.Stop();
        playerObject.currentHealth = playerObject.health;
        this.transform.localPosition = startZone.position;
    }
}
