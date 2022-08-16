using TMPro;
using UnityEngine;

public class ScoreWriter : MonoBehaviour
{
    [SerializeField] TMP_Text trapScoreText;
    [SerializeField] TMP_Text pathScoreText;

    ScoreCollector scoreCollector;

    private void Awake()
    {
        scoreCollector = FindObjectOfType<ScoreCollector>();
        
        //trapScoreText.text += scoreCollector.GetTrapScore();
        //pathScoreText.text += scoreCollector.GetPathScore();
    }

    private void Update()
    {
        SetTrapScoreText(trapScoreText, "Traps: ");
        SetPathScoreText(pathScoreText, "Path: ");
    }

    private void SetTrapScoreText(TMP_Text textObject, string text)
    {
        if (scoreCollector != null && trapScoreText != null)
        {
            // originalText = textObject.text;
            textObject.text = text + scoreCollector.GetTrapScore();
        }
    }

    private void SetPathScoreText(TMP_Text textObject, string text)
    {
        if (scoreCollector != null && pathScoreText != null)
        {
            //string originalText = textObject.text;
            textObject.text = text + scoreCollector.GetPathScore();
        }
    }
}
