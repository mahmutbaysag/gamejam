using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reddBtn : MonoBehaviour
{
    public GameObject mainCS;
    public void OnMouseDown()
    {
        mainCS = GameObject.FindGameObjectWithTag("MainCamera");
        mainCS.GetComponent<main>().soruDegistir(0);
        Debug.Log("Karar Reddedildi");
    }
}
