using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class devamBtn : MonoBehaviour
{
    public GameObject mainCS;
    public void OnMouseDown()
    {
        Debug.Log("dsf");
        mainCS = GameObject.FindGameObjectWithTag("MainCamera");
        mainCS.GetComponent<main>().sonrakiLvlYukle();
    }
}
