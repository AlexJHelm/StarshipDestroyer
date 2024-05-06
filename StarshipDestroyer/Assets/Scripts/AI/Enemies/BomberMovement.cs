using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomberMovement : MonoBehaviour
{
    [SerializeField] Transform mainTarget;
    [SerializeField] float rotationalDamp = .5f;
    [SerializeField] float movementSpeed = 10f;

    public int health = 100;



    public void Start()
    {
        if (GameManager.GM.allyWeakpointsDestroyed == 0)
        {
            mainTarget = GameObject.FindWithTag("AllyThrusters").transform;
        }
        else if (GameManager.GM.allyWeakpointsDestroyed == 1)
        {
            mainTarget = GameObject.FindWithTag("AllyBridge").transform;
        }
        else
        {
            mainTarget = GameObject.FindWithTag("AllyWeapons").transform;
        }
    }

    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        if (GameManager.GM.allyWeakpointsDestroyed == 0)
        {
            mainTarget = GameObject.FindWithTag("AllyThrusters").transform;
        }
        else if(GameManager.GM.allyWeakpointsDestroyed == 1)
        {
            mainTarget = GameObject.FindWithTag("AllyBridge").transform;
        }
        else
        {
            mainTarget = GameObject.FindWithTag("AllyWeapons").transform;
        }
        Turn();
        Move();
    }

    void Turn()
    {
        if(GameManager.GM.allyWeakpointsDestroyed < 2)
        {
            Vector3 pos = (mainTarget.position + new Vector3(50, 0, 0)) - transform.position;
            Quaternion rotation = Quaternion.LookRotation(pos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationalDamp * Time.deltaTime);
        }
        else if (GameManager.GM.allyWeakpointsDestroyed == 2)
        {
            Vector3 pos = (mainTarget.position - new Vector3(80, 0, 0)) - transform.position;
            Quaternion rotation = Quaternion.LookRotation(pos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationalDamp * Time.deltaTime);
        }

    }

    private void Move()
    {

        transform.position += transform.forward * movementSpeed * Time.deltaTime;
        
    }
}
