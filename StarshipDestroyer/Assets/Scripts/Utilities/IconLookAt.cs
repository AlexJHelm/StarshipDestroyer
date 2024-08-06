using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconLookAt : MonoBehaviour
{
    public GameObject iconTarget1;
    public GameObject iconTarget2;
    public GameObject iconTarget3;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(iconTarget1.transform);
        transform.LookAt(iconTarget2.transform);
        transform.LookAt(iconTarget3.transform);
    }
}
