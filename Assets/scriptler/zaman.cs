using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class zaman : MonoBehaviour
{
    
    public float sure=30;
    public GameObject mainCS;

    // Update is called once per frame
    void Update()
    {
        if (sure > 0)
        {
            sure -= Time.deltaTime;
            GameObject.FindGameObjectWithTag("zaman").GetComponent<Text>().text = ((int)sure).ToString();
        }
        else
        {
            mainCS = GameObject.FindGameObjectWithTag("MainCamera");
            mainCS.GetComponent<main>().kontrolNoktasi();
        }
       
    }

    public void sifirla()
    {
        sure = 30;
    }
}
