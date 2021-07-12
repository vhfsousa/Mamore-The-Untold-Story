using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilForLamp : MonoBehaviour
{
    [SerializeField] private GameObject oilForLampRaycast;

    void Update()
    {
        
    }

    public void EsperandoSerUtilizado(){
        this.gameObject.SetActive(true);
    }
    public void RecarregarLampada(){
        oilForLampRaycast.GetComponent<OilForLampRaycast>().lampFuel += 100;
        this.gameObject.SetActive(false);
        oilForLampRaycast.GetComponent<OilForLampRaycast>().semOleo = false;
    }
}