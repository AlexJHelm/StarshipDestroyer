using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public int health = 100;
    public float movementSpeed = 10f;

    public Booster booster;
    public HealthBooster healthBooster;
    public AmmoBooster ammoBooster;

    int boosterNum;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            boosterNum = Random.Range(1, 4);
            if(boosterNum == 1)
            {
                Instantiate(booster, transform.position, transform.rotation);
                Destroy(gameObject);
            }
            else if(boosterNum == 2)
            {
                Instantiate(ammoBooster, transform.position, transform.rotation);
                Destroy(gameObject);
            }
            else
            {
                Instantiate(healthBooster, transform.position, transform.rotation);
                Destroy(gameObject);
            }
            
        }
        Move();
    }

    private void Move()
    {
        transform.position += -transform.right * movementSpeed * Time.deltaTime;
    }
}
