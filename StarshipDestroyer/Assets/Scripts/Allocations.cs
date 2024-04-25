using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Allocations : MonoBehaviour
{
    Text textfeild;
    int number;

    // Start is called before the first frame update
    void Start()
    {
        textfeild = gameObject.Find("Amount").GetComponent<Text>();
    }

    public void changeText()
    {
        number += 10;

        textFeild.text = "" + number;
    }

}
