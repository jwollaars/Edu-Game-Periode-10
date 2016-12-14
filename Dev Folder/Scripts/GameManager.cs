using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject m_Game;
    public GameObject Game
    {
        get { return m_Game; }
        set { m_Game = value; }
    }

    [SerializeField]
    private GameObject m_Managers;
    public GameObject Managers
    {
        get { return m_Managers; }
        set { m_Managers = value; }
    }

    private GameObject m_CurrentGame;
    private GameObject m_CurrentManagers;

    private ProgressInfo m_Progress = new ProgressInfo();
    public ProgressInfo Progress
    {
        get { return m_Progress; }
        set { m_Progress = value; }
    }

    void Start()
    {
        m_CurrentManagers = gameObject;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            GameObject game = Instantiate(m_Game, Vector3.zero, Quaternion.identity) as GameObject;
            GameObject managers = Instantiate(m_Managers, Vector3.zero, Quaternion.identity) as GameObject;

            m_CurrentGame = game;

            managers.GetComponent<GameManager>().Game = game;
            managers.GetComponent<GameManager>().Managers = managers;

            Destroy(m_CurrentGame);
            Destroy(m_CurrentManagers);
        }
    }
}
