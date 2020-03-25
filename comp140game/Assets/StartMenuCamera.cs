using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuCamera : MonoBehaviour
{
    [SerializeField]
    private float fullRotationTime = 10f;
    private float amountToRotate;

    private Camera mainCam;
    
    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
        amountToRotate = 360 / fullRotationTime;
    }

    // Update is called once per frame
    void Update()
    {
        mainCam.transform.Rotate(new Vector3(0, amountToRotate * Time.deltaTime, 0), Space.World);
    }
}
