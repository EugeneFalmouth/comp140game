using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBehaviour : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;

    private int score = 0;

    public void UpdateScore(int value)
    {
        score += value;
        scoreText.text = score.ToString();
    }
}
