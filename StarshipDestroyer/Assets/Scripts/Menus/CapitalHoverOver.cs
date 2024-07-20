using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CapitalHoverOver : MonoBehaviour, IPointerEnterHandler
{
    public GameObject HoverPanel1;
    public GameObject HoverPanel2;
    public GameObject HoverPanel3;
    public Vector3 panelPosition;
    public Vector3 inFocusPosition = new Vector3(311, 215, 0);
    public Vector3 outOfFocusPosition = new Vector3(-1000, -1000, 0);

    public void OnPointerEnter(PointerEventData eventData)
    {
        HoverPanel1.transform.position = inFocusPosition;
        HoverPanel2.transform.position = outOfFocusPosition;
        HoverPanel3.transform.position = outOfFocusPosition;

    }
}