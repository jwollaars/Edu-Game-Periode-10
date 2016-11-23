using UnityEngine;
using System.Collections;

public class Components : MonoBehaviour
{
    [Header("Local Components")]
    public GameManager GameManager;
    public InputController InputController;
    public MenuController MenuController;
    public ColorController ColorController;

    [Header("Global Components")]
    public PlayerController PlayerController;

    [Header("Needed GameObjects")]
    public GameObject m_Player;

    void Awake()
    {
        PlayerController = m_Player.GetComponent<PlayerController>();
    }
}