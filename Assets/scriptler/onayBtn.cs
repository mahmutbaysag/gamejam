using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onayBtn : MonoBehaviour
{
    public GameObject mainCS;
    public void OnMouseDown()
    {
        mainCS = GameObject.FindGameObjectWithTag("MainCamera");
        mainCS.GetComponent<main>().soruDegistir();
        Debug.Log("Karar Onaylandý");
    }
}
