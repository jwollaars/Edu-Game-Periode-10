using UnityEngine;
using System.Collections;

public class TargetController : MonoBehaviour
{
    private Components m_Components;

    [SerializeField]
    private GameObject m_Highlight;

    [SerializeField]
    private int m_Target;
    public int GetTarget
    {
        get { return m_Target; }
        set { m_Target = value; }
    }

    void Start()
    {
        m_Components = GetComponent<Components>();
    }

    void Update()
    {
        if (m_Target > m_Components.ColorController.GetEnemyObjects.Count - 1)
        {
            m_Target = 0;
        }
        else if (m_Target < 0)
        {
            m_Target = m_Components.ColorController.GetEnemyObjects.Count - 1;
        }

        if (m_Components.ColorController.GetEnemyObjects.Count != 0 && (m_Target <= m_Components.ColorController.GetEnemyObjects.Count && m_Target >= 0))
        {
            if (m_Components.ColorController.GetEnemyObjects[m_Target] != null)
            {
                m_Highlight.transform.position = m_Components.ColorController.GetEnemyObjects[m_Target].transform.position;
                m_Highlight.SetActive(true);
            }
            else
            {
                m_Highlight.SetActive(false);
            }
        }
        else
        {
            m_Highlight.SetActive(false);
            m_Target = 0;
        }
    }

    public void NextTarget()
    {
        m_Target += 1;
    }

    public void PreviousTarget()
    {
        m_Target -= 1;
    }
}
