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

        if (m_Components.InputController.GetKeyStates[2])
        {
            transform.position -= new Vector3(1 + m_Speed, 0) * Time.deltaTime;
        }
        else if (m_Components.InputController.GetKeyStates[3])
        {
            transform.position += new Vector3(1 + m_Speed, 0) * Time.deltaTime;
        }

        if (m_Components.InputController.GetKeyStates[4])
        {
            m_Components.TargetController.NextTarget();
            m_Components.InputController.UseKeyOnce(4);
        }
        else if (m_Components.InputController.GetKeyStates[5])
        {
            m_Components.TargetController.PreviousTarget();
            m_Components.InputController.UseKeyOnce(5);
        }

        if (m_Components.InputController.GetKeyStates[6])
        {
            if(m_Components.ColorController.ContrastCheck(m_Components.ColorController.GetTargetColorContrast, m_Components.ColorController.GetPlayerColor, m_Components.ColorController.GetEnemyColors[m_Components.TargetController.GetTarget]))
            {
                Destroy(m_Components.ColorController.GetEnemyObjects[m_Components.TargetController.GetTarget]);
                m_Components.ColorController.GetEnemyObjects.RemoveAt(m_Components.TargetController.GetTarget);
                m_Components.ColorController.GetEnemyColors.RemoveAt(m_Components.TargetController.GetTarget);

                m_Components.GameManager.Progress.AddScore();
            }
            else
            {
                Destroy(m_Components.ColorController.GetEnemyObjects[m_Components.TargetController.GetTarget]);
                m_Components.ColorController.GetEnemyObjects.RemoveAt(m_Components.TargetController.GetTarget);
                m_Components.ColorController.GetEnemyColors.RemoveAt(m_Components.TargetController.GetTarget);

                m_Components.GameManager.Progress.RemoveScore();
            }
            m_Components.InputController.UseKeyOnce(6);
        }
    }
}
