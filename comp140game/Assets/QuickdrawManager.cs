using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuickdrawManager : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject enemy;

    [SerializeField]
    private Text quickdrawText;

    [SerializeField]
    private Text countdownText;

    private float startTimer = 4f;

    private float deathTimer;

    private bool gameEnded = false;

    // Start is called before the first frame update
    void Start()
    {
        //If the other game mode was selected, disable the functionality of this one
        if (Manager.choice != Manager.GameChoice.quickdraw)
        {
            gameObject.SetActive(false);
        }

        deathTimer = Random.Range(1f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        if (startTimer > 0)
        {
            countdownText.text = Mathf.CeilToInt(startTimer).ToString();
            if (Input.GetButtonDown("Fire1"))
            {
                gameEnded = true;
                quickdrawText.text = "You shot too fast. You lose!";
                countdownText.gameObject.SetActive(false);
            }
            if (!gameEnded)
            {
                startTimer -= Time.deltaTime;
            }
        }
        else
        {
            countdownText.gameObject.SetActive(false);
            if (deathTimer <= 0)
            {
                quickdrawText.text = "You got shot. You lose!";
                gameEnded = true;
            }
            if(!gameEnded)
            {
                deathTimer -= Time.deltaTime;
            }
        }
        if (!enemy.activeSelf && !gameEnded)
        {
            quickdrawText.text = "You Win!";
            gameEnded = true;
        }
    }
}
