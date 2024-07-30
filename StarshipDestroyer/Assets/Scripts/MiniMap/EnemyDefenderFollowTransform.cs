using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDefenderFollowTransform : MonoBehaviour
{
    public Transform target;
    public Vector3 Offset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.GM.enemyDefendersAlive > 0)
        {
            target = GameObject.FindWithTag("EnemyDefender").transform;
            transform.position = target.transform.position + Offset;
        }
    }
}
