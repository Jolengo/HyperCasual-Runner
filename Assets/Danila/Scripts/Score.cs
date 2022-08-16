using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Score : MonoBehaviour
{
    [SerializeField] int scorePath;
    [SerializeField] float totalPath;
    Vector2 currentPosition;
    Vector2 previousPosition;

    void Start()
    {
        currentPosition = gameObject.transform.position;
        previousPosition = gameObject.transform.position;
    }
    void Update()
    {
        CountPath();
    }

    private void CountPath()
    {
        currentPosition = gameObject.transform.position;
        totalPath += Math.Abs(currentPosition.x - previousPosition.x);
        previousPosition = gameObject.transform.position;
        scorePath = (int)totalPath;
    }

    

    public int GetScorePath()
    {
        return scorePath;
    }
}
