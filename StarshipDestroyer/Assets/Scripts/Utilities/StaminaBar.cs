using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public Slider staminaBar;
    public ShipController boosterTimer;
    private void Start()
    {
        if(GameManager.GM.laserSystemActive == true)
        {
            boosterTimer = GameObject.FindGameObjectWithTag("PlayerLaser").GetComponent<ShipController>();
        }
        else if(GameManager.GM.bombSystemActive == true)
        {
            boosterTimer = GameObject.FindGameObjectWithTag("PlayerBomb").GetComponent<ShipController>();
        }
        else if (GameManager.GM.missileSystemActive == true)
        {
            boosterTimer = GameObject.FindGameObjectWithTag("PlayerMissile").GetComponent<ShipController>();
        }      
        //healthBar = GetComponent<Slider>();
        staminaBar.maxValue = boosterTimer.maxBoosterTimer * 130;
        staminaBar.value = boosterTimer.boosterTimer;
    }
    public void Update()
    {
        staminaBar.value = boosterTimer.boosterTimer;
    }
}
