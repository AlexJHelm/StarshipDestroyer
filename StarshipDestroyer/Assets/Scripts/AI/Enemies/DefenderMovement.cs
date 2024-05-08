using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderMovement : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Transform patrolPoint;
    [SerializeField] float patrolRotationalDamp = .5f;
    [SerializeField] float chasingRotationalDamp = .5f;
    [SerializeField] float movementSpeed = 10f;
    public bool isChasing = false;

    public int health = 100;



    public void Start()
    {
        //playerTarget = GameObject.FindWithTag("Player").transform;
        patrolPoint = GameObject.FindWithTag("EnemyDefenderPatrolPos").transform;
    }

    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        Turn();
        Move();
    }

    void Turn()
    {
        if (isChasing == true)
        {
            target = transform.gameObject.GetComponent<DefenderAttack>().aggroColliders[0].transform;
            Vector3 pos = target.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(pos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, chasingRotationalDamp * Time.deltaTime);
        }
        if (isChasing == false)
        {
            Vector3 pos = patrolPoint.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(pos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, patrolRotationalDamp * Time.deltaTime);
        }
    }

    private void Move()
    {
        if (isChasing == true)
        {
            transform.position += transform.forward * movementSpeed * Time.deltaTime;
        }
        else
        {
            transform.position += transform.forward * movementSpeed / 2 * Time.deltaTime;
        }

    }
}
