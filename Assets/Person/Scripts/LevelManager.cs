using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float sceneLoadDelay = 1f;

    ScoreCollector scoreCollector;

    private void Start()
    {
        scoreCollector = FindObjectOfType<ScoreCollector>();
    }

    public void LoadScene(string name)
    {
        SaveScore();
        SceneManager.LoadScene(name);
    }

    public void LoadScene(int number)
    {
        SaveScore();
        SceneManager.LoadScene(number);
    }

    public void WaitAndLoadScene(string name)
    {
        SaveScore();
        StartCoroutine(WaitAndLoad(name, sceneLoadDelay));
    }

    IEnumerator WaitAndLoad(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void SaveScore()
    {
        if (scoreCollector != null)
        {
            scoreCollector.InitializeScore();
            DontDestroyOnLoad(scoreCollector.gameObject);
        }
    }
}
