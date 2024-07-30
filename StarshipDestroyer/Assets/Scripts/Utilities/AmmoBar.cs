using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoBar : MonoBehaviour
{
    public Slider ammoBar;
    public Laser laserCooldown;
    private void Start()
    {
        laserCooldown = GameObject.FindGameObjectWithTag("Player").GetComponent<Laser>();
        //healthBar = GetComponent<Slider>();
        ammoBar.maxValue = laserCooldown.maxLaserCooldown;
        ammoBar.value = laserCooldown.laserCooldown;
    }
    public void Update()
    {
        ammoBar.value = laserCooldown.laserCooldown;
    }
}
