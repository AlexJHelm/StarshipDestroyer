using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public Slider healthBar;
    public ShipController playerHealth;
    private void Start()
    {
        if(GameManager.GM.laserSystemActive == true)
        {
            playerHealth = GameObject.FindGameObjectWithTag("PlayerLaser").GetComponent<ShipController>();
        }
        else if (GameManager.GM.bombSystemActive == true)
        {
            playerHealth = GameObject.FindGameObjectWithTag("PlayerBomb").GetComponent<ShipController>();
        }
        else if (GameManager.GM.missileSystemActive == true)
        {
            playerHealth = GameObject.FindGameObjectWithTag("PlayerMissile").GetComponent<ShipController>();
        }

        //healthBar = GetComponent<Slider>();
        healthBar.maxValue = playerHealth.maxHealth;
        healthBar.value = playerHealth.maxHealth;
    }
    public void Update()
    {
        healthBar.value = playerHealth.health;
    }
}
