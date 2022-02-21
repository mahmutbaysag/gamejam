using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basla : MonoBehaviour
{
    public GameObject baslaPrefab;
    public GameObject zaman;
    public void OnMouseDown()
    {
        baslaPrefab = GameObject.Find("initScreen");
        Destroy(baslaPrefab);

        zaman = GameObject.FindGameObjectWithTag("MainCamera");
        zaman.GetComponent<zaman>().sifirla();
    }
}
