using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElementalUIController : MonoBehaviour {

    public ElementController controller;

    [Header("Element Images")]
    public Image darkMatter;
    public Image solar;
    public Image cosmic;
	void Start () {
        ResetUI();
    }
	
	void Update () {
		if(darkMatter.GetComponent<Elemental>().element == controller.currentElement)
        {
            darkMatter.enabled = true;
            solar.enabled = false;
            cosmic.enabled = false;
        }
        else if(solar.GetComponent<Elemental>().element == controller.currentElement)
        {
            darkMatter.enabled = false;
            solar.enabled = true;
            cosmic.enabled = false;
        }
        else if (cosmic.GetComponent<Elemental>().element == controller.currentElement)
        {
            darkMatter.enabled = false;
            solar.enabled = false;
            cosmic.enabled = true;
        }

    }

    private void ResetUI()
    {
        darkMatter.enabled = false;
        solar.enabled = false;
        cosmic.enabled = false;
    }
}
