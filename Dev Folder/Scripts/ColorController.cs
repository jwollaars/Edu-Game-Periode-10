using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ColorController : MonoBehaviour
{
    [SerializeField]
    private GameObject m_PlayerObject;
    private Color m_PlayerColor;
    public Color PlayerColor
    {
        get { return m_PlayerColor; }
        set { m_PlayerColor = value; }
    }

    [SerializeField]
    private List<GameObject> m_EnemyObjects = new List<GameObject>();
    public List<GameObject> GetEnemyObjects
    {
        get { return m_EnemyObjects; }
        set { m_EnemyObjects = value; }
    }
    [SerializeField]
    private List<Color> m_EnemyColors = new List<Color>();
    public List<Color> GetEnemyColors
    {
        get { return m_EnemyColors; }
    }

    [SerializeField]
    private List<GameObject> m_BackgroundLanes = new List<GameObject>();
    public List<GameObject> GetBackgroundLanes
    {
        get { return m_BackgroundLanes; }
    }
    [SerializeField]
    private List<Color> m_BackgroundLaneColors = new List<Color>();
    public List<Color> GetBackgroundLaneColors
    {
        get { return m_BackgroundLaneColors; }
    }

    private Color m_CorrectColor;

    private float m_Range = 0.2f;

    private string m_TargetColorContrast = "Complementary";
    public string GetTargetColorContrast
    {
        get { return m_TargetColorContrast; }
        set { m_TargetColorContrast = value; }
    }

    void Start()
    {
        Setup();
    }

    void Update()
    {
    }

    private void Setup()
    {
        m_PlayerColor = m_PlayerObject.GetComponent<SpriteRenderer>().color;

        for (int i = 0; i < m_BackgroundLanes.Count; i++)
        {
            m_BackgroundLanes[i].GetComponent<SpriteRenderer>().color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            m_BackgroundLaneColors.Add(m_BackgroundLanes[i].GetComponent<SpriteRenderer>().color);
        }
    }

    public Color ContrastCorrect(string contrastType)
    {
        switch (contrastType)
        {
            case "ColorToColor":
                return new Color(0, 0, 0, 0);

            case "LightDark":
                return new Color(0, 0, 0, 0);

            case "WarmCold":
                return new Color(0, 0, 0, 0);

            case "Complementary":
                float r = 1 - m_PlayerColor.r;
                float g = 1 - m_PlayerColor.g;
                float b = 1 - m_PlayerColor.b;

                return new Color(r + Random.Range(-m_Range, m_Range), g + Random.Range(-m_Range, m_Range), b + Random.Range(-m_Range, m_Range), 1);

            case "Simultaan":
                return new Color(0, 0, 0, 0);

            case "Analogous":
                return new Color(m_PlayerColor.r + Random.Range(-m_Range, m_Range), m_PlayerColor.g + Random.Range(-m_Range, m_Range), m_PlayerColor.b + Random.Range(-m_Range, m_Range), 1);

            case "Kwantiteit":
                return new Color(0, 0, 0, 0);

            default:
                return new Color(0, 0, 0, 0);
        }
    }

    public bool ContrastCheck(string contrastType, Color playerColor, Color otherColor)
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

                    float acceptableRange = m_Range;

                    if ((otherColor.r <= rightColor.r + acceptableRange && otherColor.g <= otherColor.g + acceptableRange && otherColor.b <= otherColor.b + acceptableRange) &&
                        (otherColor.r >= rightColor.r - acceptableRange && otherColor.g >= otherColor.g - acceptableRange && otherColor.b >= otherColor.b - acceptableRange))
                    {
                        //otherColor = new Color(0, 0, 0, 0);
                        return true;
                    }
                    //otherColor = new Color(0, 0, 0, 0);
                    return false;

                case "Simultaan":
                    return false;

                case "Analogous":

                    float range = m_Range;

                    if((otherColor.r <= playerColor.r + range && otherColor.g <= playerColor.g + range && otherColor.b <= playerColor.b + range) &&
                       (otherColor.r >= playerColor.r - range && otherColor.g >= playerColor.g - range && otherColor.b >= playerColor.b - range))
                    {
                        //otherColor = new Color(0, 0, 0, 0);
                        return true;
                    }
                    //otherColor = new Color(0, 0, 0, 0);
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
        //m_TargetEnemyColor = go.GetComponent<SpriteRenderer>().color;
    }

    public void Check()
    {

    }

    public void AddEnemy(GameObject enemy)
    {
        m_EnemyObjects.Add(enemy);
        m_EnemyColors.Add(enemy.GetComponent<SpriteRenderer>().color);
    }
}