using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float fireDistance = 100f;

    private Camera cam;

    [SerializeField]
    private Transform quickdrawSpawnPoint;
    [SerializeField]
    private Transform dogpileSpawnPoint;

    [SerializeField]
    private Image crosshair;

    [SerializeField]
    private GameObject weapon;

    void Start()
    {
        cam = GetComponentInChildren<Camera>();
        ResolveSpawnPosition();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out RaycastHit hit, fireDistance))
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
