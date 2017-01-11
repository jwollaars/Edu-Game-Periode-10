using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnController : MonoBehaviour
{
    private Components m_Components;

    private bool m_Play = false;

    [Header("Objects info")]
    [SerializeField]
    private List<GameObject> m_Prefabs;
    [SerializeField]
    private Color m_CorrectColor;

    [Header("Spawner Options")]
    [SerializeField]
    private List<Vector3> m_SpawnPositions;
    [SerializeField]
    private float m_SpawnRate;
    [SerializeField]
    private float m_Cooldown;
    private float m_SpawnTimer;
    [SerializeField]
    private string m_TargetContrast;

    void Start()
    {
        m_Components = GetComponent<Components>();
        Setup();
    }

    void Update()
    {
        if (m_Play)
        {
            if (TimeController())
            {
                SpawnObstacle(0, Random.Range(0, m_SpawnPositions.Count - 1));
            }
        }
    }

    public void SpawnObstacle(int prefabID, int spawnPosition, bool tutorial)
    {
        for (int i = 0; i < m_Components.ColorController.GetEnemyObjects.Count; i++)
        {
            if(m_SpawnPositions[spawnPosition] == m_Components.ColorController.GetEnemyObjects[i].transform.position)
            {
                spawnPosition += 1;
                i = 0;
            }
        }

        GameObject clone = Instantiate(m_Prefabs[prefabID], m_SpawnPositions[spawnPosition], Quaternion.identity) as GameObject;
        //clone.transform.SetParent(m_Components.GameManager.Game.transform);

        m_CorrectColor = m_Components.ColorController.ContrastCorrect(m_TargetContrast);
        int check = Random.Range(0, 10);

        if ((check >= 0 && check <= 5) || tutorial)
        {
            clone.GetComponent<SpriteRenderer>().color = m_CorrectColor;
        }
        else if (!tutorial)
        {
            clone.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1);
        }

        m_Components.ColorController.AddEnemy(clone);

        m_Components.GarbageDisposal.AddGarbage(clone, 10);
    }

    public void SpawnObstacle(int prefabID, int spawnPosition)
    {
        for (int i = 0; i < m_Components.ColorController.GetEnemyObjects.Count; i++)
        {
            if (m_SpawnPositions[spawnPosition] == m_Components.ColorController.GetEnemyObjects[i].transform.position)
            {
                spawnPosition += 1;
                i = 0;
            }
        }

        GameObject clone = Instantiate(m_Prefabs[prefabID], m_SpawnPositions[spawnPosition], Quaternion.identity) as GameObject;
        //clone.transform.SetParent(m_Components.GameManager.Game.transform);

        m_CorrectColor = m_Components.ColorController.ContrastCorrect(m_TargetContrast);
        int check = Random.Range(0, 10);

        if ((check >= 0 && check <= 5))
        {
            clone.GetComponent<SpriteRenderer>().color = m_CorrectColor;
        }
        else
        {
            clone.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1);
        }

        m_Components.ColorController.AddEnemy(clone);

        m_Components.GarbageDisposal.AddGarbage(clone, 10);
    }

    private bool TimeController()
    {
        m_SpawnTimer -= Time.deltaTime;

        if (m_SpawnTimer <= 0)
        {
            m_SpawnTimer = m_Cooldown;
            return true;
        }
        return false;
    }

    private void Setup()
    {
        m_SpawnTimer = m_Cooldown;
    }

    public void Play(bool play)
    {
        m_Play = play;
    }
}
