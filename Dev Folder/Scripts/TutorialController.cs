using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TutorialController : MonoBehaviour
{
    private Components m_Components;

    [SerializeField]
    private bool m_OnOff;

    [Header("Info")]
    [SerializeField]
    private Color m_StartColor;
    private const float m_TimeToWait = 2f;
    private float m_Timer = 2f;

    [SerializeField]
    private List<GameObject> m_TutorialScreens = new List<GameObject>();

    void Start()
    {
        m_Components = GetComponent<Components>();

        if (m_OnOff)
        {
            m_Components.m_Player.GetComponent<SpriteRenderer>().color = m_StartColor;
        }
    }

    void Update()
    {
        if (m_OnOff)
        {
            m_Timer -= Time.deltaTime;
            if (m_Timer <= 0)
            {
                for (int i = 0; i < m_TutorialScreens.Count; i++)
                {
                    if (m_TutorialScreens[i] != null)
                    {
                        m_TutorialScreens[i].SetActive(true);

                        if (m_TutorialScreens[i].name == "Tutorial 1")
                        {
                            m_Components.SpawnController.SpawnObstacle(0, 5, false);
                        }
                        else if (m_TutorialScreens[i].name == "Tutorial 2")
                        {
                            m_Components.SpawnController.SpawnObstacle(0, 5, true);
                        }

                        break;
                    }

                    if (i == m_TutorialScreens.Count)
                    {
                        m_OnOff = false;
                    }
                }

                if (m_TutorialScreens[0].name == "Tutorial 0" || m_TutorialScreens[0].name == "Tutorial 3")
                {
                    Time.timeScale = 0;
                }
                else
                {
                    Time.timeScale = 0.2f;
                }

                m_Timer = m_TimeToWait;
            }

            for (int i = 0; i < 4; i++)
            {
                if (m_Components.InputController.GetKeyStates[i] && m_TutorialScreens[0].name == "Tutorial 0")
                {
                    Destroy(m_TutorialScreens[0]);
                    m_TutorialScreens.RemoveAt(0);
                    Time.timeScale = 1;
                }
            }

            if (Input.GetKeyDown(KeyCode.Space) && m_TutorialScreens[0].name == "Tutorial 1")
            {
                Destroy(m_TutorialScreens[0]);
                m_TutorialScreens.RemoveAt(0);
                Time.timeScale = 1;
            }

            if (Input.GetKeyDown(KeyCode.R) && m_TutorialScreens[0].name == "Tutorial 2")
            {
                Destroy(m_TutorialScreens[0]);
                m_TutorialScreens.RemoveAt(0);
                Time.timeScale = 1;
            }

            if (Input.GetKeyDown(KeyCode.Space) && m_TutorialScreens[0].name == "Tutorial 3")
            {
                Destroy(m_TutorialScreens[0]);
                m_TutorialScreens.RemoveAt(0);
                Time.timeScale = 1;
                m_OnOff = false;
            }
        }
    }
}
