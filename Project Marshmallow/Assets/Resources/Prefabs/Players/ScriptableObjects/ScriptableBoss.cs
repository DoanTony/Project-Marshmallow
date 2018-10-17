using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BossTracker", order = 0)]
public class ScriptableBoss : ScriptableObject {

    public List<GameObject> orbs = new List<GameObject>();

    private void OnDisable()
    {
        orbs.Clear();
    }

    public void RemoveFromList(GameObject _object)
    {
        if (orbs.Contains(_object))
        {
            orbs.Remove(_object);
        }
    }

    public void AddSelf(GameObject _object)
    {
        orbs.Add(_object);
    }
}
