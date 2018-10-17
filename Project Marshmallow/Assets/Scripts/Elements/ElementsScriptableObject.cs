using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "ElementType", menuName = "Element", order = 0)]
public class ElementsScriptableObject : ScriptableObject {


    public GameObject projectilePrefab;
    public GameObject enemyProjectilePrefab;

    public List<ElementsScriptableObject> weakness = new List<ElementsScriptableObject>();
}
