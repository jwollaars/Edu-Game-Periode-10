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

    void Start()
    {
        m_KeyStates = new bool[m_Keys.Length];
    }

    void Update()
    {
        for (int i = 0; i < m_Keys.Length; i++)
        {
            if(Input.GetKeyDown(m_Keys[i]))
            {
                m_KeyStates[i] = true;
            }

            if(Input.GetKeyUp(m_Keys[i]))
            {
                m_KeyStates[i] = false;
            }
        }
    }

    void UseKeyOnce(int key)
    {
        m_KeyStates[key] = false;
    }
}
