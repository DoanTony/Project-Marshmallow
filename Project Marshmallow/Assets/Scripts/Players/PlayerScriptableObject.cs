using UnityEngine;
using UnityEditor;

[CreateAssetMenu(menuName = "Player", order = 0)]
public class PlayerScriptableObject : ScriptableObject
{
    public int health;
    [HideInInspector] public float currentHealth;

    public void ReduceHealth()
    {
        currentHealth--;
    }

    private void OnEnable()
    {
        currentHealth = health;        
    }

    private void OnDisable()
    {
        currentHealth = health;
    }

}