using UnityEngine;
using System.Collections;

public class Components : MonoBehaviour
{
    [Header("Local Components")]
    [SerializeField]
    public GameManager GameManager;
    [SerializeField]
    public InputController InputController;
    [SerializeField]
    public MenuController MenuController;

    [Header("Global Components")]
    public PlayerController PlayerController;

    [Header("Needed GameObjects")]
    public GameObject m_Player;

    void Awake()
    {
        PlayerController = m_Player.GetComponent<PlayerController>();
    }
}