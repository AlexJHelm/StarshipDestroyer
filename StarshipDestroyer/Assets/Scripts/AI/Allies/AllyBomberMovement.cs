using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyBomberMovement : MonoBehaviour
{
    [SerializeField] Transform mainTarget;
    [SerializeField] float rotationalDamp = .5f;
    [SerializeField] float movementSpeed = 10f;

    public int health = 100;

    public GameObject destructionVFX;

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
            Instantiate(destructionVFX, gameObject.transform.position, gameObject.transform.rotation);
            AudioManagerScript.instance.Play("Explosion");
            GameManager.GM.bombersAlive -= 1;
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

    //Turn Function
    void Turn()
    {
        //Initially checks to see if the enemy weapons are destroyed
        if (GameManager.GM.enemyWeaponsDestroyed == false)
        {
            //If the enemy weapons game object exists and is the main target, perform following actions
            if (mainTarget == GameObject.FindWithTag("EnemyWeapons").transform)
            {
                //Updates position in respect to enemy weapons
                Vector3 pos = (mainTarget.position + new Vector3(80, 0, 0)) - transform.position;
                //Sets new rotation for new position
                Quaternion rotation = Quaternion.LookRotation(pos);
                //Creates the rotation for new position
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationalDamp * Time.deltaTime);
            }
            //If the main target is not the enemy weapons, then perform these following actions
            else
            {
                //General position update
                Vector3 pos = (mainTarget.position - new Vector3(50, 0, 0)) - transform.position;
                //Sets new rotation for new position
                Quaternion rotation = Quaternion.LookRotation(pos);
                //Creates the rotation for new position
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationalDamp * Time.deltaTime);
            }
        }
        //If enemy weapons are destroyed, perform these following actions
        else
        {
            //General position update
            Vector3 pos = (mainTarget.position - new Vector3(50, 0, 0)) - transform.position;
            //Sets new rotation for new position
            Quaternion rotation = Quaternion.LookRotation(pos);
            //Creates the rotation for new position
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationalDamp * Time.deltaTime);
        }
    }

    private void Move()
    {
        transform.position += transform.forward * movementSpeed * Time.deltaTime;
    }
}
