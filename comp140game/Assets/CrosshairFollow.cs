using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrosshairFollow : MonoBehaviour
{
    [SerializeField]
    private Image crosshair;

    // Update is called once per frame
    void Update()
    {
        crosshair.rectTransform.position = Input.mousePosition;
    }
}
