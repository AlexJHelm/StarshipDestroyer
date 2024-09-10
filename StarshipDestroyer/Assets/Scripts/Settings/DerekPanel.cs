using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DerekPanel : MonoBehaviour, IPointerEnterHandler
{
    public GameObject AlexPanel1;
    public GameObject DerekPanel2;
    public GameObject JacobPanel3;
    public GameObject KylePanel4;
    public void OnPointerEnter(PointerEventData eventData)
    {
        AlexPanel1.SetActive(false);
        DerekPanel2.SetActive(true);
        JacobPanel3.SetActive(false);
        KylePanel4.SetActive(false);

    }
}
