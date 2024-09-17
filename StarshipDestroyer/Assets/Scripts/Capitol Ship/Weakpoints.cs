using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weakpoints : MonoBehaviour
{
    //Variable Declaration

    public float weakpointHealth = 100;
    public float maxWeakpointHealth = 100;
    public bool canTakeDamage = true;
    public bool takingDamage = false;

    public GameObject gm;
    public GameObject destructionVFX1;
    public GameObject destructionVFX2;
    public GameObject destructionVFX3;
    public GameObject destructionVFX4;
    public GameObject destructionVFX5;
    public GameObject destructionVFX6;

    bool isDestroyed = false;

    //Methods

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager");
        if(GameManager.GM.shipHealthUpgradeUnlocked == true)
        {
            if(gameObject.tag == "AllyThrusters" || gameObject.tag == "AllyBridge" || gameObject.tag == "AllyWeapons")
            {
                weakpointHealth = weakpointHealth * 2;
                maxWeakpointHealth = maxWeakpointHealth * 2;
            }
        }
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
                    Instantiate(destructionVFX1, gameObject.transform.position, gameObject.transform.rotation);
                }
                else if (gameObject.tag == "EnemyBridge")
                {
                    gm.GetComponent<GameManager>().enemyBridgeDestroyed = true;
                    Instantiate(destructionVFX2, gameObject.transform.position, gameObject.transform.rotation);
                }
                else
                {
                    gm.GetComponent<GameManager>().enemyThrustersDestroyed = true;
                    Instantiate(destructionVFX3, gameObject.transform.position, gameObject.transform.rotation);
                }
                gm.GetComponent<GameManager>().enemyWeakpointsDestroyed++;               
            }
            else
            {
                if(gameObject.tag == "AllyThrusters")
                {
                    Instantiate(destructionVFX4, gameObject.transform.position, gameObject.transform.rotation);
                    Destroy(GameObject.FindWithTag("AllyEngineExhaust"));
                }
                else if(gameObject.tag == "AllyBridge")
                {
                    Instantiate(destructionVFX5, gameObject.transform.position, gameObject.transform.rotation);
                }
                else
                {
                    Instantiate(destructionVFX6, gameObject.transform.position, gameObject.transform.rotation);
                }
                gm.GetComponent<GameManager>().allyWeakpointsDestroyed++;
            }          
            isDestroyed = true;           
        }

        //Destroys weakpoint when its health reaches 0
        if(isDestroyed == true)
        {
            AudioManagerScript.instance.Play("Explosion");
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