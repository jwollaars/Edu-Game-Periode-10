using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ColorController : MonoBehaviour
{
    [SerializeField]
    private GameObject m_PlayerObject;
    private Color m_PlayerColor;

    [SerializeField]
    private List<GameObject> m_EnemyObjects = new List<GameObject>();
    private List<Color> m_EnemyColors = new List<Color>();

    [SerializeField]
    private Color m_TargetEnemyColor;

    //[SerializeField]
    //private List<GameObject> m_Pathways = new List<GameObject>();
    //private List<GameObject> m_PathColors;

    void Start()
    {
        Setup();
    }

    void Update()
    {
        ContrastCheck("Complementary", m_PlayerColor, ref m_TargetEnemyColor);
    }

    private void Setup()
    {
        m_TargetEnemyColor = m_EnemyObjects[0].GetComponent<SpriteRenderer>().color;
        m_PlayerColor = m_PlayerObject.GetComponent<SpriteRenderer>().color;
    }

    public bool ContrastCheck(string contrastType, Color playerColor, ref Color otherColor)
    {
        if (otherColor != new Color(0, 0, 0, 0))
        {
            switch (contrastType)
            {
                case "ColorToColor":
                    return false;
                case "LightDark":
                    return false;
                case "WarmCold":
                    return false;
                case "Complementary":

                    float r = 1 - playerColor.r;
                    float g = 1 - playerColor.g;
                    float b = 1 - playerColor.b;

                    Color rightColor = new Color(r, g, b, 1);

                    float acceptableRange = 0.1f;

                    if ((otherColor.r <= rightColor.r + acceptableRange && otherColor.g <= otherColor.g + acceptableRange && otherColor.b <= otherColor.b + acceptableRange) &&
                        (otherColor.r >= rightColor.r - acceptableRange && otherColor.g >= otherColor.g - acceptableRange && otherColor.b >= otherColor.b - acceptableRange))
                    {
                        otherColor = new Color(0, 0, 0, 0);
                        return true;
                    }
                    otherColor = new Color(0, 0, 0, 0);
                    return false;

                case "Simultaan":
                    return false;

                case "Analogous":

                    float range = 0.1f;

                    if((otherColor.r <= playerColor.r + range && otherColor.g <= playerColor.g + range && otherColor.b <= playerColor.b + range) &&
                       (otherColor.r >= playerColor.r - range && otherColor.g >= playerColor.g - range && otherColor.b >= playerColor.b - range))
                    {
                        otherColor = new Color(0, 0, 0, 0);
                        return true;
                    }
                    otherColor = new Color(0, 0, 0, 0);
                    return false;

                case "Kwantiteit":
                    return false;
                default:
                    return false;
            }
        }
        return false;
    }

    public void SetTargetEnemyColor(GameObject go)
    {
        m_TargetEnemyColor = go.GetComponent<SpriteRenderer>().color;
    }

    public void AddEnemy(GameObject enemy)
    {
        m_EnemyObjects.Add(enemy);
        m_EnemyColors.Add(enemy.GetComponent<SpriteRenderer>().color);
    }
}