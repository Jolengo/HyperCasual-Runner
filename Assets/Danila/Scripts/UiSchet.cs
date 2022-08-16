using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiSchet : MonoBehaviour
{
    [SerializeField] TMP_Text ScoreText;
    ScoreKeeper scoreKeeper;

    private void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();

    }

    private void Update()
    {
        ScoreText.text = scoreKeeper.GetScore().ToString();
    }
}
