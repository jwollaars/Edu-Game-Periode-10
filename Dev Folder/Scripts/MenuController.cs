using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour
{
    private Components m_Components;

    [SerializeField]
    private GameObject m_MainMenu;
    [SerializeField]
    private GameObject m_InGameMenu;

    void Start()
    {
        m_Components = GetComponent<Components>();
        Time.timeScale = 0;
    }

    public void StartGame()
    {
        MenuActive(m_MainMenu);
        MenuActive(m_InGameMenu);

        m_Components.GameManager.Game.SetActive(true);
        m_Components.GameManager.Progress = new ProgressInfo();

        m_Components.SpawnController.Play(true);
        m_Components.InputController.Play();
        Time.timeScale = 1;
    }

    public void PauseGame()
    {
        if (Time.timeScale != 0)
        {
            Time.timeScale = 0;
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }

    public void SetMenu(GameObject menuPanel)
    {
        if (menuPanel.activeSelf == false)
        {
            menuPanel.SetActive(true);
        }
        else if(menuPanel.activeSelf == true)
        {
            menuPanel.SetActive(false);
        }
    }

    public void MenuActive(GameObject menu)
    {
        if (menu.activeSelf == false)
        {
            menu.SetActive(true);
        }
        else if (menu.activeSelf == true)
        {
            menu.SetActive(false);
        }
    }
}