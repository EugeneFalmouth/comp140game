using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogpileManager : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject[] enemies;

    private List<Vector3> enemySpawnLocations;
    private List<Vector3> enemyMoveLocations;

    private float enemyMoveTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        enemySpawnLocations = new List<Vector3>();
        enemyMoveLocations = new List<Vector3>();
        for (int i = 0; i < enemies.Length; i++)
        {
            enemySpawnLocations.Add(enemies[i].transform.position);
        }


        enemyMoveLocations.Add(new Vector3(enemySpawnLocations[0].x + 3f, enemySpawnLocations[0].y, enemySpawnLocations[0].z));
        enemyMoveLocations.Add(new Vector3(enemySpawnLocations[1].x - 1f, enemySpawnLocations[1].y, enemySpawnLocations[1].z - 3f));
        enemyMoveLocations.Add(new Vector3(enemySpawnLocations[2].x - 3f, enemySpawnLocations[2].y, enemySpawnLocations[2].z));
        enemyMoveLocations.Add(new Vector3(enemySpawnLocations[3].x + 1f, enemySpawnLocations[3].y, enemySpawnLocations[3].z - 3f));
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].transform.LookAt(player.transform.position);
            if (enemies[i].activeSelf)
            {
                enemies[i].transform.position = Vector3.MoveTowards(enemies[i].transform.position, enemyMoveLocations[i], enemyMoveTime * Time.deltaTime);
            }
            else
            {
                enemies[i].SetActive(true);
                enemies[i].transform.position = enemySpawnLocations[i];
            }
        }
    }
}
