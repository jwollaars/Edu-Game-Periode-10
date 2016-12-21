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

    private float m_ClosestDistance;

    void Start()
    {
        m_Components = GetComponent<Components>();
    }

    void Update()
    {
        m_Target = 0;
        m_ClosestDistance = 500;
        
        for (int i = 0; i < m_Components.ColorController.GetEnemyObjects.Count; i++)
        {
            float distance = Vector2.Distance(m_Components.ColorController.PlayerObject.transform.position, m_Components.ColorController.GetEnemyObjects[i].transform.position);

            if(distance <= m_ClosestDistance)
            {
                m_ClosestDistance = distance;
                m_Target = i;
            }
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
