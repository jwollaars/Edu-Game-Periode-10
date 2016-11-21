using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject m_MainMenu;
    [SerializeField]
    private GameObject m_InGameMenu;

    private GameManager m_GameManager;

    void Start()
    {
        m_GameManager = GameObject.Find("Managements").GetComponent<GameManager>();
    }

    public void StartGame()
    {
        MenuActive(m_MainMenu);
        MenuActive(m_InGameMenu);

        m_GameManager.Game.SetActive(true);
        m_GameManager.Progress = new ProgressInfo();
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