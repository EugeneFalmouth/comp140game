using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public void Die()
    {
        //Work in progress. Add animation or motion of dying
        Destroy(gameObject);
    }
}
