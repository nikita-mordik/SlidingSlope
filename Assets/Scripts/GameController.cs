using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    static GameController instance;
    public static GameController Instance { get => instance; }

    public int score;
    public int Score { get => score; set => score = value; }

    private static bool isLose;
    public static bool IsLose { get => isLose; set => isLose = value; }

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
}