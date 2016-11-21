using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    private Components m_Components;

    [SerializeField]
    private int m_Speed = 1;
    
    void Start()
    {
        m_Components = GameObject.Find("Managements").GetComponent<Components>();
    }

    void Update()
    {
        if(m_Components.InputController.GetKeyStates[0])
        {
            transform.position += new Vector3(0, 1 + m_Speed) * Time.deltaTime;
        }
        else if (m_Components.InputController.GetKeyStates[1])
        {
            transform.position -= new Vector3(0, 1 + m_Speed) * Time.deltaTime;
        }
    }
}
