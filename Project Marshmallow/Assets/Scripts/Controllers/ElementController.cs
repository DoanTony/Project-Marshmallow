using UnityEngine;

[CreateAssetMenu(menuName = "Element Controller", order= 0)]
public class ElementController : ScriptableObject {

    public ElementsScriptableObject currentElement = null;

    private void OnEnable()
    {
        currentElement = null;
    }

    private void OnDisable()
    {
        currentElement = null;
    }
}
