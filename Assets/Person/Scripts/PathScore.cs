using System;
using UnityEngine;

public class PathScore : MonoBehaviour
{
    int scorePath;
    float totalPath;
    Vector2 currentPosition;
    Vector2 previousPosition;

    private void Awake()
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
        scorePath = (int) totalPath;
    }

    float VectorCounting(Vector2 a, Vector2 b)
    {
        float x = b.x - a.x;
        float y = b.y - a.y;
        float path = Mathf.Sqrt(x * x + y * y);
        return path;
    }

    public int GetScore()
    {
        return scorePath;
    }
}