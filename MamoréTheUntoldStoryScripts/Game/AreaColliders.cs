using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaColliders : MonoBehaviour
{
    public bool podeFotografar;


    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            podeFotografar = true;
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            podeFotografar = false;
        }
    }
}
