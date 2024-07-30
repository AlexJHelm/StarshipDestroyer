using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBomberFollowTransform : MonoBehaviour
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
        if (GameManager.GM.enemyBombersAlive > 0)
        {
            target = GameObject.FindWithTag("EnemyBomber").transform;
            transform.position = target.transform.position + Offset;
        }
    }
}
