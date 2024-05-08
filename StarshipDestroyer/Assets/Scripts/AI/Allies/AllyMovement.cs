using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyMovement : MonoBehaviour
{
    [SerializeField] Transform enemyTarget;
    [SerializeField] Transform defaultTarget;
    [SerializeField] float rotationalDamp = .5f;
    [SerializeField] float movementSpeed = 10f;
    public bool isChasing = false;

    public int health = 100;



    public void Start()
    {
        //enemyTarget = GameObject.FindWithTag("Player").transform;
        defaultTarget = GameObject.FindWithTag("AllyDefaultTarget").transform;
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
            enemyTarget = transform.gameObject.GetComponent<AllyAttack>().aggroColliders[0].transform;
            Vector3 pos = enemyTarget.position - transform.position;
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
