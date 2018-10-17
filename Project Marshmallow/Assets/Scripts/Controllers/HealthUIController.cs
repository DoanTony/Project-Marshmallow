using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUIController : MonoBehaviour {

    public Slider healthBar;
    public PlayerScriptableObject playerReference;

	void Update () {
        healthBar.value = playerReference.currentHealth / 10;		
	}
}
