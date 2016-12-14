using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GarbageDisposal : MonoBehaviour
{
    private Components m_Components;

    private List<GameObject> m_GarbageBin = new List<GameObject>();
    private List<float> m_RemainingTime = new List<float>();
    
    void Start()
    {
        m_Components = GetComponent<Components>();
    }

    void Update()
    {
        for (int i = 0; i < m_GarbageBin.Count; i++)
        {
            m_RemainingTime[i] -= Time.deltaTime;

            if(m_RemainingTime[i] <= 0)
            {
                GameObject go = m_GarbageBin[i];

                if (go != null)
                {
                    m_Components.ColorController.GetEnemyColors.Remove(go.GetComponent<SpriteRenderer>().color);
                    m_Components.ColorController.GetEnemyObjects.Remove(go);
                }

                m_GarbageBin.Remove(go);
                m_RemainingTime.Remove(m_RemainingTime[i]);
                Destroy(go);
            }
        }
    }

    public void AddGarbage(GameObject go, float remainingTime)
    {
        m_GarbageBin.Add(go);
        m_RemainingTime.Add(remainingTime);
    }
}