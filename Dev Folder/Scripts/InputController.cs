using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour
{
    [SerializeField]
    private KeyCode[] m_Keys;

    private bool[] m_KeyStates;
    public bool[] GetKeyStates
    {
        get { return m_KeyStates; }
    }

    private bool m_Play = false;

    void Start()
    {
        m_KeyStates = new bool[m_Keys.Length];
    }

    void Update()
    {
        if (m_Play)
        {
            for (int i = 0; i < m_Keys.Length; i++)
            {
                if (Input.GetKeyDown(m_Keys[i]))
                {
                    m_KeyStates[i] = true;
                }

                if (Input.GetKeyUp(m_Keys[i]))
                {
                    m_KeyStates[i] = false;
                }
            }
        }
    }

    public void UseKeyOnce(int key)
    {
        m_KeyStates[key] = false;
    }

    public void Play()
    {
        m_Play = true;
    }
}
