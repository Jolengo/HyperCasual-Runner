using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSchetchik : MonoBehaviour
{
    [SerializeField] private int coins;
    [SerializeField] public Text Textcoins;
    ScoreKeeper scoreKeeper;
    private void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Monetki")
        {
            coins++;
            other.gameObject.SetActive(false);
            scoreKeeper.ModifyScore(1);
            Textcoins.text = coins.ToString();
        }
    }
}
