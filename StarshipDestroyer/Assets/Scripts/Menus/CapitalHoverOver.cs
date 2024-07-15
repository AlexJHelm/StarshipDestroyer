using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CapitalHoverOver : MonoBehaviour, IPointerEnterHandler
{
    public GameObject HoverPanel1;
    public GameObject HoverPanel2;
    public GameObject HoverPanel3;

    public void OnPointerEnter(PointerEventData eventData)
    {
        HoverPanel1.SetActive(true);
        HoverPanel2.SetActive(false);
        HoverPanel3.SetActive(false);

    }
}