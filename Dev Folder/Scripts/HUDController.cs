using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUDController : MonoBehaviour
{
    private Components m_Components;

    [SerializeField]
    private Text m_Contrast;
    [SerializeField]
    private Text m_Score;
    [SerializeField]
    private Text m_Mistakes;

    void Start()
    {
        m_Components = GetComponent<Components>();
    }

    void Update()
    {
        m_Contrast.text = "Contrast: " + m_Components.ColorController.GetTargetColorContrast;
        m_Score.text = "Score: " + m_Components.GameManager.Progress.Score;
        m_Mistakes.text = "Mistakes: " + m_Components.GameManager.Progress.Mistakes + "/3";
    }
}
