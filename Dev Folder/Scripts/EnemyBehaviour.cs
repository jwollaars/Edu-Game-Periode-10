using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour
{
    void Update ()
    {
        transform.position += new Vector3(-1 * 2 * Time.deltaTime,0,0);
	}
}
