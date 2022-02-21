using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tekrarBasla : MonoBehaviour
{
    public GameObject mainCS;
    public void OnMouseDown()
    {
        GameObject.Find("kaybetScreen").transform.Rotate(new Vector3(0, +90, 0));
        mainCS = GameObject.FindGameObjectWithTag("MainCamera");
        mainCS.GetComponent<main>().kararSayaci = 0;
        mainCS.GetComponent<main>().isletmeSayaci = 0;
        mainCS.GetComponent<main>().yeniIsletmeYukle();
    }
}
