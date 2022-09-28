using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int score = 0;

    private void Awake()
    {
        if(!instance)
        {
            instance = this;
        }
    }

    public void AddScore(int coinValue)
    {
        score += coinValue;
        Debug.Log("[Points]: " + score);
    }
}
