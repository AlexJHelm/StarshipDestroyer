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
        boosterTimer = GameObject.FindGameObjectWithTag("Player").GetComponent<ShipController>();
        //healthBar = GetComponent<Slider>();
        staminaBar.maxValue = boosterTimer.maxBoosterTimer * 130;
        staminaBar.value = boosterTimer.boosterTimer;
    }
    public void Update()
    {
        staminaBar.value = boosterTimer.boosterTimer;
    }
}
