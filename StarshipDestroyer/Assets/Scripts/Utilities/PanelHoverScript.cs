using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelHoverScript : MonoBehaviour
{
    public GameObject HoverPanel1;
    public GameObject HoverPanel2;
    public GameObject HoverPanel3;

    public void CapitolShipPanel()
    {
        HoverPanel1.SetActive(true);
        HoverPanel2.SetActive(false);
        HoverPanel3.SetActive(false);
    }

    public void AllocationPanel()
    {
        HoverPanel1.SetActive(false);
        HoverPanel2.SetActive(true);
        HoverPanel3.SetActive(false);
    }

    public void WeaponsPanel()
    {
        HoverPanel1.SetActive(false);
        HoverPanel2.SetActive(false);
        HoverPanel3.SetActive(true);
    }
}
