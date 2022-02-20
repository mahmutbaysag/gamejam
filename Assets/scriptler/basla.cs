using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basla : MonoBehaviour
{
    public void OnMouseDown()
    {
        Destroy(GameObject.FindGameObjectWithTag("initScreen"));
    }
}
