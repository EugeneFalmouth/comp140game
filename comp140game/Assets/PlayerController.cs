using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float fireDistance = 1000f;

    [SerializeField]
    private Transform quickdrawSpawnPoint;
    [SerializeField]
    private Transform dogpileSpawnPoint;

    [SerializeField]
    private Image crosshair;

    [SerializeField]
    private GameObject weapon;

    [SerializeField]
    private Camera cam;

    void Start()
    {
        ResolveSpawnPosition();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray.origin, ray.direction, out hit, fireDistance))
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (hit.collider.gameObject.CompareTag("Enemy"))
                {
                        hit.collider.gameObject.GetComponent<EnemyScript>().Die();
                }
            }
        }

        Vector3 mousePos = Input.mousePosition;
        crosshair.rectTransform.position = mousePos;
        mousePos.z = 0.4f;
        weapon.transform.position = cam.ScreenToWorldPoint(mousePos);
        weapon.transform.position = new Vector3(weapon.transform.position.x, weapon.transform.position.y - 0.3f, weapon.transform.position.z);

        //Vector3 weaponDirection = transform.right;
        //weaponDirection *= -100;
        //Debug.Log("pre-position: " + weaponDirection);
        //weaponDirection = new Vector3(weapon.transform.position.x, weapon.transform.position.y, weaponDirection.z);
        //Debug.Log("post-position: " + weaponDirection);
        //weapon.transform.LookAt(weaponDirection);

        weapon.transform.LookAt(hit.point);
    }

    private void ResolveSpawnPosition()
    {
        if (Manager.choice == Manager.GameChoice.quickdraw)
        {
            gameObject.transform.position = quickdrawSpawnPoint.position;
            gameObject.transform.rotation = quickdrawSpawnPoint.rotation;
        }
        else if (Manager.choice == Manager.GameChoice.dogpile)
        {
            gameObject.transform.position = dogpileSpawnPoint.position;
            gameObject.transform.rotation = dogpileSpawnPoint.rotation;
        }
    }
}
