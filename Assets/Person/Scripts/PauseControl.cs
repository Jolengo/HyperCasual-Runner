using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseControl : MonoBehaviour
{
    // ���� ���������� �������� ������-����, ������� ��� ������ ���� �� ����� 
    [SerializeField] GameObject pauseMenu = null;

    bool isPaused;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMode();
            if (isPaused)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }

    void PauseMode()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0 : 1;
        pauseMenu.SetActive(isPaused);
    }

    public bool GetIsPaused() { return isPaused; }

    // ��������� ��� ��� ������� ���� � ������������ ���������� ������� �� ����� ����� � ���� ������ DestroyTrap
    /*
    private void Awake()
    {
        pauseSystem = FindObjectOfType<PauseSystem>();
    }
    private void OnMouseDown()
    {
        if (!pauseSystem.GetIsPaused()) 
        {
            Destroy(Trap);
            Instantiate(Particle, transform.position, transform.rotation);
        }
    }
     */
}
