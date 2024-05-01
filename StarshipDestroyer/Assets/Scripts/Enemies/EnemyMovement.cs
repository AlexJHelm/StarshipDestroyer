using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]Transform playerTarget;
    [SerializeField]Transform defaultTarget;
    [SerializeField]float rotationalDamp = .5f;
    [SerializeField]float movementSpeed = 10f;
    public bool isChasing = false;

    public int health = 100;



    public void Start()
    {
        playerTarget = GameObject.FindWithTag("Player").transform;
        defaultTarget = GameObject.FindWithTag("EnemyDefaultTarget").transform;
    }

    void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
        Turn();
        Move();
    }

    void Turn()
    {
        if(isChasing == true)
        {
            Vector3 pos = playerTarget.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(pos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationalDamp * Time.deltaTime);
        }
        if (isChasing == false)
        {
            Vector3 pos = defaultTarget.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(pos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationalDamp * Time.deltaTime);
        }
    }

    private void Move()
    {
        if(isChasing == true)
        {
            transform.position += transform.forward * movementSpeed * Time.deltaTime;
        }
        else
        {
            transform.position += transform.forward * movementSpeed/2 * Time.deltaTime;
        }
        
    }
}
