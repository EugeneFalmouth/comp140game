using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager
{
    public enum GameChoice
    {
        quickdraw,
        dogpile
    }

    public static int score = 0;

    public static GameChoice choice = GameChoice.quickdraw;
}
