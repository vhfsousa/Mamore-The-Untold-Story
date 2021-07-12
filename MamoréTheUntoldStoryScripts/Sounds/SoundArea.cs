using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundArea : MonoBehaviour
{
    private bool podeTocarSom;
    [SerializeField] private AudioSource audioS;
    [SerializeField] private AudioClip areaSound;

    void Start()
    {
        podeTocarSom = true;
        audioS.gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col){
        if(podeTocarSom == true){
            if(col.gameObject.CompareTag("Player")){
                audioS.PlayOneShot(areaSound);
                podeTocarSom = false;
            }
        }
    }
}