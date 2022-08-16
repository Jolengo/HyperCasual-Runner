using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCollector : MonoBehaviour
{
    [SerializeField] TrapScore trapScore;
    [SerializeField] PathScore pathScore;

    static ScoreCollector instance;

    public int totalTrapScore;
    public int totalPathScore;

    void Awake()
    {
        ManageSingleton();
        InitializeScore();
    }

    private void Update()
    {
        InitializeScore();
    }

    void ManageSingleton()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void InitializeScore()
    {
        trapScore = FindObjectOfType<TrapScore>();
        pathScore = FindObjectOfType<PathScore>();
        if (trapScore != null)
        {
            totalTrapScore = trapScore.GetScore();
        }
        if (pathScore != null)
        {
            totalPathScore = pathScore.GetScore();
        }
    }

    public void SetTotalTrapScore(int score)
    {
        totalTrapScore = score;
    }

    public void SetTotalPathScore(int score)
    {
        totalPathScore = score;
    }

    public int GetTrapScore()
    {
        return totalTrapScore;
    }

    public int GetPathScore()
    {
        return totalPathScore;
    }

    public void ResetScore()
    {
        totalTrapScore = 0;
        totalPathScore = 0;
    }
}
