using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementWellRotator : MonoBehaviour {

    public GameObject darkMatterElementObject;
    public GameObject solarElementObject;
    public GameObject cosmicElementObject;

    public float delayBetweenRotation = 5.0f;


    [Range(0, 2)]
    private int index = 0;
	void Start () {
        StartCoroutine(RotateElementIndex());
	}

    private IEnumerator RotateElementIndex()
    {
        int tempIndex = Random.Range(0, 3);
        while(tempIndex == index)
        {
            tempIndex = Random.Range(0, 3);
        }
        index = tempIndex;
        yield return new WaitForSeconds(delayBetweenRotation);
        StartCoroutine(RotateElementIndex());
    }

    void Update () {
        switch (index)
        {
            case 0:
                darkMatterElementObject.SetActive(true);
                solarElementObject.SetActive(false);
                cosmicElementObject.SetActive(false);
                break;
            case 1:
                darkMatterElementObject.SetActive(false);
                solarElementObject.SetActive(true);
                cosmicElementObject.SetActive(false);
                break;
            case 2:
                darkMatterElementObject.SetActive(false);
                solarElementObject.SetActive(false);
                cosmicElementObject.SetActive(true);
                break;
        }
	}



}
