using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    private Components m_Components;

    [Header("Movement")]
    [SerializeField]
    private int m_HorizontalSpeed = 1;
    [SerializeField]
    private int m_VerticalSpeed = 1;

    [Header("Components")]
    [SerializeField]
    private SpriteRenderer m_SpriteRenderer;
    [SerializeField]
    private Animator m_Animator;

    private Coroutine m_AttackCoroutine;

    void Start()
    {
        m_Components = GameObject.Find("Managements").GetComponent<Components>();
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (m_Components.InputController.GetKeyStates[0])
        {
            transform.position += new Vector3(0, 1 + m_VerticalSpeed) * Time.deltaTime;
            m_Animator.SetFloat("Moving", 1);
        }
        else if (m_Components.InputController.GetKeyStates[1])
        {
            transform.position -= new Vector3(0, 1 + m_VerticalSpeed) * Time.deltaTime;
            m_Animator.SetFloat("Moving", -1);
        }
        else
        {
            m_Animator.SetFloat("Moving", 0);
        }

        if (m_Components.InputController.GetKeyStates[2])
        {
            transform.position -= new Vector3(1 + m_HorizontalSpeed, 0) * Time.deltaTime;
        }
        else if (m_Components.InputController.GetKeyStates[3])
        {
            transform.position += new Vector3(1 + m_HorizontalSpeed, 0) * Time.deltaTime;
        }

        if (m_Components.InputController.GetKeyStates[6])
        {
            if (m_AttackCoroutine == null)
            {
                m_AttackCoroutine = StartCoroutine(DashAttack(0.3f, 9));
            }

            m_Animator.SetBool("Attack", true);
            m_Components.InputController.UseKeyOnce(6);
        }
    }

    void OnCollisionStay2D(Collision2D collider)
    {
        if (m_Components.InputController.GetKeyStates[7] && collider.gameObject.tag == "Background")
        {
            Color tempCol = collider.gameObject.GetComponent<SpriteRenderer>().color;

            Color col = new Color((m_Components.ColorController.PlayerColor.r + tempCol.r) / 2, (m_Components.ColorController.PlayerColor.g + tempCol.g) / 2, (m_Components.ColorController.PlayerColor.b + tempCol.b) / 2, 1);
            m_SpriteRenderer.color = col;
            m_Animator.SetBool("Tong", true);
        }
        else
        {
            m_Animator.SetBool("Tong", false);
        }

        if (collider.gameObject.tag == "Enemy" && m_AttackCoroutine != null)
        {
            if (!m_Components.ColorController.ContrastCheck(m_Components.ColorController.GetTargetColorContrast, m_Components.ColorController.PlayerColor, collider.gameObject.GetComponent<SpriteRenderer>().color))
            {
                m_Animator.SetBool("Attack", false);
                m_Components.ColorController.GetEnemyObjects.Remove(collider.gameObject);
                m_Components.ColorController.GetEnemyColors.Remove(collider.gameObject.GetComponent<SpriteRenderer>().color);
                Destroy(collider.gameObject);
                StopCoroutine(m_AttackCoroutine);
                m_AttackCoroutine = null;
                m_Components.GameManager.Progress.AddScore();
            }
            else if (m_Components.ColorController.ContrastCheck(m_Components.ColorController.GetTargetColorContrast, m_Components.ColorController.PlayerColor, collider.gameObject.GetComponent<SpriteRenderer>().color))
            {
                m_Animator.SetBool("Attack", false);
                StopCoroutine(m_AttackCoroutine);
                m_AttackCoroutine = null;
                m_Components.GameManager.Progress.RemoveScore();
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        //Debug.Log(collider.gameObject.tag);

    }

    IEnumerator DashAttack(float time, float length)
    {
        float elapsedTime = 0;
        Vector3 startingPos = transform.position;

        while (elapsedTime < time)
        {
            transform.position = Vector3.Lerp(startingPos, (startingPos + new Vector3(length, 0)), (elapsedTime / time));
            elapsedTime += Time.deltaTime;

            if (elapsedTime >= time)
            {
                m_Animator.SetBool("Attack", false);
                yield break;
            }

            yield return null;
        }

        yield return new WaitForSeconds(0);
    }
}