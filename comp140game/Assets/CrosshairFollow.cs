using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrosshairFollow : MonoBehaviour
{
    [SerializeField]
    private Image crosshair;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        crosshair.rectTransform.position = Input.mousePosition;
    }
}
