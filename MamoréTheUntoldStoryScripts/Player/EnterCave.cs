using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterCave : MonoBehaviour
{
    [SerializeField] private AudioSource somAmbienteJogo;
    [SerializeField] private AudioSource somCaverna;

    void Start(){
        somAmbienteJogo.enabled = true;
        somCaverna.enabled = false;
    }

    void OnTriggerEnter(Collider col){
        somAmbienteJogo.enabled = false;
        somCaverna.enabled = true;
    }

    void OnTriggerExit(Collider col){
        somAmbienteJogo.enabled = true;
        somCaverna.enabled = false;
    }
}
