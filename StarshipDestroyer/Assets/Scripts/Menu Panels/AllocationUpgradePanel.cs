using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AllocationUpgradePane : MonoBehaviour, IPointerEnterHandler
{
    public GameObject HoverPanel1;
    public GameObject HoverPanel2;
    public GameObject HoverPanel3;
    public void OnPointerEnter(PointerEventData eventData)
    {
        HoverPanel1.SetActive(true);
        HoverPanel2.SetActive(false);
        HoverPanel3.SetActive(false);
        if (GameManager.GM.laserSystemActive == true)
        {
            GameObject.FindWithTag("LaserEquipped").gameObject.GetComponent<Image>().color = new Color32(36, 144, 48, 255);
        }
        else
        {
            GameObject.FindWithTag("LaserEquipped").gameObject.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
        }

    }
}