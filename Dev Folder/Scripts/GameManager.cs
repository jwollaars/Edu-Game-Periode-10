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

    private ProgressInfo m_Progress;
    public ProgressInfo Progress
    {
        get { return m_Progress; }
        set { m_Progress = value; }
    }
}
