using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapScore : MonoBehaviour
{
    [SerializeField] int scoreForTrap;
    int totalScore = 0;

    public void AddScore()
    {
        totalScore += scoreForTrap;
    }

    public int GetScore()
    {
        return totalScore;
    } 
}
