using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }

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
        //0.4f is the distance from the player object to where the gun should be
        mousePos.z = 0.4f;
        weapon.transform.position = cam.ScreenToWorldPoint(mousePos);
        weapon.transform.position = new Vector3(weapon.transform.position.x, weapon.transform.position.y - 0.3f, weapon.transform.position.z);
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
