using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weakpoints : MonoBehaviour
{
    //Variable Declaration

    public float weakpointHealth = 100;
    public bool canTakeDamage = true;
    public bool takingDamage = false;

    public GameObject gm;

    bool isDestroyed = false;

    //Methods

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager");
    }
    
    // Update is called once per frame
    void Update()
    {
        //Adds up total weak points destroyed
        if (weakpointHealth <= 0)
        {
            if(gameObject.tag == "EnemyThrusters" || gameObject.tag == "EnemyBridge" || gameObject.tag == "EnemyWeapons")
            {
                if (gameObject.tag == "EnemyWeapons")
                {
                    gm.GetComponent<GameManager>().enemyWeaponsDestroyed = true;
                }
                else if (gameObject.tag == "EnemyBridge")
                {
                    gm.GetComponent<GameManager>().enemyBridgeDestroyed = true;
                }
                else
                {
                    gm.GetComponent<GameManager>().enemyThrustersDestroyed = true;
                }
                gm.GetComponent<GameManager>().enemyWeakpointsDestroyed++;               
            }
            else
            {
                gm.GetComponent<GameManager>().allyWeakpointsDestroyed++;
            }          
            isDestroyed = true;           
        }

        //Destroys weakpoint when its health reaches 0
        if(isDestroyed == true)
        {
            Destroy(gameObject);
        }

        //Starts the Invulnerability window
        if(takingDamage == true)
        {
            StartCoroutine(InvulnWindow());
            takingDamage = false;
        }
    }

    //Invulnerability window coroutine
    public IEnumerator InvulnWindow()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(1f);
        canTakeDamage = true;
    }
}