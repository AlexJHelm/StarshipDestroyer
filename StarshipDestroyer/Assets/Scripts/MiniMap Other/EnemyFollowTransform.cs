using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowTransform : MonoBehaviour
{
    public Transform target;
    public Vector3 Offset;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.GM.enemyFightersAlive > 0)
        {
            target = GameObject.FindWithTag("Enemy").transform;
            transform.position = target.transform.position + Offset;
        }
    }
}
