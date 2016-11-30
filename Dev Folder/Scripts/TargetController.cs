using UnityEngine;
using System.Collections;

public class TargetController : MonoBehaviour
{
    private Components m_Components;

    [SerializeField]
    private GameObject m_Highlight;

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
        if (m_Components.ColorController.GetEnemyObjects[m_Target] != null)
        {
            m_Highlight.transform.position = m_Components.ColorController.GetEnemyObjects[m_Target].transform.position;
            m_Highlight.SetActive(true);
        }
        else
        {
            m_Highlight.SetActive(false);
            m_Target = 0;
        }
    }

    public void NextTarget()
    {
        if (m_Target <= m_Components.ColorController.GetEnemyObjects.Count)
        {
            m_Target++;
        }
        else
        {
            m_Target = 0;
        }
    }

    public void PreviousTarget()
    {
        if (m_Target >= 0)
        {
            m_Target--;
        }
        else
        {
            m_Target = m_Components.ColorController.GetEnemyObjects.Count;
        }
    }
}
