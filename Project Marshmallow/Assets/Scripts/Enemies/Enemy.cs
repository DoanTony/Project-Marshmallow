using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour, ITakeDamage
{
    public float health = 1;
    public ElementsScriptableObject type;
    public ScriptableBoss bossTracker;

    public void Start()
    {
        if(this.tag == "Orb")
        {
            bossTracker.AddSelf(this.gameObject);
        }
    }

    public void TakeDamage(ElementsScriptableObject _element)
    {
        if(this.tag == "Boss")
        {
            if(bossTracker.orbs.Count <= 0)
            {
                --health;
            }
        }
        else if(this.tag == "Orb")
        {
            --health;
            bossTracker.RemoveFromList(this.gameObject);
        }
        else if (this.tag == "Enemy")
        {
            if (type.weakness.Contains(_element))
            {
                --health;
                Debug.Log("Weakness");
            }
            else
            {
                Debug.Log("Not Weakness");
            }
          
        }
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void OnDestroy()
    {
        // Add features when is destroyed
    }

}
