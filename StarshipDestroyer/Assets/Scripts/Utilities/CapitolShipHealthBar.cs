using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CapitolShipHealthBar : MonoBehaviour
{
    public Slider healthBar;
    public Weakpoints weakpointHealth;
    private void Start()
    {              
        healthBar.maxValue = weakpointHealth.maxWeakpointHealth;
        healthBar.value = weakpointHealth.weakpointHealth;
    }
    public void Update()
    {
        healthBar.value = weakpointHealth.weakpointHealth;
    }
}
