using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicShotBar : MonoBehaviour
{
    public Slider basicShotBar;
    public BasicShot shotCooldown;
    private void Start()
    {
        shotCooldown = GameObject.FindGameObjectWithTag("Player").GetComponent<BasicShot>();
        //healthBar = GetComponent<Slider>();
        basicShotBar.maxValue = shotCooldown.maxShotCooldown;
        basicShotBar.value = shotCooldown.shotCooldown;
    }
    public void Update()
    {
        basicShotBar.value = shotCooldown.shotDuration;
    }
}
