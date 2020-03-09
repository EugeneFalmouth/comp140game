using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField]
    private int scoreReward = 5;

    private UIBehaviour ui;
    
    private void Start()
    {
        ui = FindObjectOfType<UIBehaviour>();
    }
    
    public void Die()
    {
        //Work in progress. Add animation or motion of dying
        ui.UpdateScore(scoreReward);
        Destroy(gameObject);
    }
}
