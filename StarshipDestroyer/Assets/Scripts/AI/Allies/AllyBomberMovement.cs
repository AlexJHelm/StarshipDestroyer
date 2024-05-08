using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyBomberMovement : MonoBehaviour
{
    [SerializeField] Transform mainTarget;
    [SerializeField] float rotationalDamp = .5f;
    [SerializeField] float movementSpeed = 10f;

    public int health = 100;



    public void Start()
    {
        if (GameManager.GM.enemyWeakpointsDestroyed == 0)
        {
            mainTarget = GameObject.FindWithTag("EnemyThrusters").transform;
        }
        else if (GameManager.GM.enemyWeakpointsDestroyed == 1)
        {
            if (GameManager.GM.enemyThrustersDestroyed == false)
            {
                mainTarget = GameObject.FindWithTag("EnemyThrusters").transform;
            }
            else if(GameManager.GM.enemyBridgeDestroyed == false)
            {
                mainTarget = GameObject.FindWithTag("EnemyBridge").transform;
            }          
        }
        else
        {
            if (GameManager.GM.enemyThrustersDestroyed == false)
            {
                mainTarget = GameObject.FindWithTag("EnemyThrusters").transform;
            }
            else if (GameManager.GM.enemyBridgeDestroyed == false)
            {
                mainTarget = GameObject.FindWithTag("EnemyBridge").transform;
            }
            else
            {
                mainTarget = GameObject.FindWithTag("EnemyWeapons").transform;
            }
            
        }
    }

    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        if (GameManager.GM.enemyWeakpointsDestroyed == 0)
        {
            mainTarget = GameObject.FindWithTag("EnemyThrusters").transform;
        }
        else if (GameManager.GM.enemyWeakpointsDestroyed == 1)
        {
            if (GameManager.GM.enemyThrustersDestroyed == false)
            {
                mainTarget = GameObject.FindWithTag("EnemyThrusters").transform;
            }
            else if (GameManager.GM.enemyBridgeDestroyed == false)
            {
                mainTarget = GameObject.FindWithTag("EnemyBridge").transform;
            }
        }
        else
        {
            if (GameManager.GM.enemyThrustersDestroyed == false)
            {
                mainTarget = GameObject.FindWithTag("EnemyThrusters").transform;
            }
            else if (GameManager.GM.enemyBridgeDestroyed == false)
            {
                mainTarget = GameObject.FindWithTag("EnemyBridge").transform;
            }
            else
            {
                mainTarget = GameObject.FindWithTag("EnemyWeapons").transform;
            }

        }
        Turn();
        Move();
    }

    void Turn()
    {
        if (GameManager.GM.enemyWeaponsDestroyed == false)
        {
            if (mainTarget == GameObject.FindWithTag("EnemyWeapons").transform)
            {
                Vector3 pos = (mainTarget.position + new Vector3(80, 0, 0)) - transform.position;
                Quaternion rotation = Quaternion.LookRotation(pos);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationalDamp * Time.deltaTime);
            }
            else
            {
                Vector3 pos = (mainTarget.position - new Vector3(50, 0, 0)) - transform.position;
                Quaternion rotation = Quaternion.LookRotation(pos);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationalDamp * Time.deltaTime);
            }
        }
        else
        {
            Vector3 pos = (mainTarget.position - new Vector3(50, 0, 0)) - transform.position;
            Quaternion rotation = Quaternion.LookRotation(pos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationalDamp * Time.deltaTime);
        }

    }

    private void Move()
    {

        transform.position += transform.forward * movementSpeed * Time.deltaTime;

    }
}
