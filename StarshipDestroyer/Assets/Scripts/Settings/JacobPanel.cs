using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JacobPanel : MonoBehaviour, IPointerEnterHandler
{
    public GameObject AlexPanel1;
    public GameObject DerekPanel2;
    public GameObject JacobPanel3;
    public GameObject KylePanel4;
    public void OnPointerEnter(PointerEventData eventData)
    {
        AlexPanel1.SetActive(false);
        DerekPanel2.SetActive(false);
        JacobPanel3.SetActive(true);
        KylePanel4.SetActive(false);

    }
}