using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueArea : MonoBehaviour
{
    [SerializeField] private AudioSource audioS;
    [SerializeField] private AudioClip clueSound;

    void Start()
    {
        audioS.gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col){
        if(col.gameObject.CompareTag("Player")){
            audioS.PlayOneShot(clueSound);
        }
    }
}