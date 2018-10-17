using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

    public LayerMask cursorTargetLayer;
    public ElementController elementController;

    public float delayBetweenShots = 2.0f;
    private bool canShoot;

    LayerMask targetLayerMask;


    // Use this for initialization
    void Start() {
        canShoot = true;
        targetLayerMask = 1 << LayerMask.NameToLayer("Target");
    }

    // Update is called once per frame
    void Update() {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, targetLayerMask))
        {
            if (hit.transform.GetComponent<Enemy>())
            {
                if (Input.GetMouseButtonDown(0))
                {
                    elementController.currentElement = hit.transform.GetComponent<Enemy>().type;
                }
            }
        }

        if (elementController.currentElement != null)
        {
            if (canShoot)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    GameObject projectile = Instantiate(elementController.currentElement.projectilePrefab, this.transform.position, this.transform.rotation);
                    canShoot = false;
                    StartCoroutine(DelayShootEnable());
                }
            }
        }
    }

    IEnumerator DelayShootEnable()
    {
        yield return new WaitForSeconds(delayBetweenShots);
        canShoot = true;
    }
}
