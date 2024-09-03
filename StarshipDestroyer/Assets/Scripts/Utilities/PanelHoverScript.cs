using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelHoverScript : MonoBehaviour
{
    public GameObject HoverPanel1;
    public GameObject HoverPanel2;
    public GameObject HoverPanel3;

    public GameObject outOfFocusPos;
    public GameObject inFocusPos;

    public void CapitolShipPanel()
    {
        AudioManagerScript.instance.Play("Click");
        HoverPanel1.transform.position = inFocusPos.transform.position;
        HoverPanel2.transform.position = outOfFocusPos.transform.position;
        HoverPanel3.transform.position = outOfFocusPos.transform.position;
    }

    public void AllocationPanel()
    {
        AudioManagerScript.instance.Play("Click");
        HoverPanel1.transform.position = outOfFocusPos.transform.position;
        HoverPanel2.transform.position = inFocusPos.transform.position;
        HoverPanel3.transform.position = outOfFocusPos.transform.position;
    }

    public void WeaponsPanel()
    {
        AudioManagerScript.instance.Play("Click");
        HoverPanel1.transform.position = outOfFocusPos.transform.position;
        HoverPanel2.transform.position = outOfFocusPos.transform.position;
        HoverPanel3.transform.position = inFocusPos.transform.position;
    }
}
