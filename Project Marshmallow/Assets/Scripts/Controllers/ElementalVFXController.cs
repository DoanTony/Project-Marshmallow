using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementalVFXController : MonoBehaviour {

    public ElementController elementController;

    [Header("Dark Matter Element")]
    public ElementsScriptableObject darkElement;
    public GameObject darkMatterHair;
    public GameObject darkMatterWand;

    [Header("Sun Matter Element")]
    public ElementsScriptableObject sunElement;
    public GameObject sunHair;
    public GameObject sunWand;

    [Header("Cosmic Matter Element")]
    public ElementsScriptableObject cosmicElement;
    public GameObject cosmicHair;
    public GameObject cosmicWand;

   
	void Update () {
        ElementsScriptableObject currentElement = elementController.currentElement;

        if(currentElement == darkElement)
        {
            darkMatterHair.SetActive(true);
            sunHair.SetActive(false);
            cosmicHair.SetActive(false);
            darkMatterWand.SetActive(true);
            sunWand.SetActive(false);
            cosmicWand.SetActive(false);
        }
        else if(currentElement == sunElement)
        {
            darkMatterHair.SetActive(false);
            sunHair.SetActive(true);
            cosmicHair.SetActive(false);
            darkMatterWand.SetActive(false);
            sunWand.SetActive(true);
            cosmicWand.SetActive(false);
        }
        else if(currentElement == cosmicElement)
        {
            darkMatterHair.SetActive(false);
            sunHair.SetActive(false);
            cosmicHair.SetActive(true);
            darkMatterWand.SetActive(false);
            sunWand.SetActive(false);
            cosmicWand.SetActive(true);
        }
        else
        {
            darkMatterHair.SetActive(false);
            sunHair.SetActive(false);
            cosmicHair.SetActive(false);
            darkMatterWand.SetActive(false);
            sunWand.SetActive(false);
            cosmicWand.SetActive(false);
        }
	}
}
