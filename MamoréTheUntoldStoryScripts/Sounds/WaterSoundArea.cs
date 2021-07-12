using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSoundArea : MonoBehaviour
{
    [SerializeField] private AudioSource audioS;

    void Start(){
        audioS.volume = 0f;
    }

    void OnTriggerEnter(Collider col){
        if(col.gameObject.CompareTag("Player")){
            StartCoroutine(AumentaSom());
        }
    }

    void OnTriggerExit(Collider col){
        if(col.gameObject.CompareTag("Player")){
            StartCoroutine(DiminuiSom());
        }
    }

    IEnumerator AumentaSom(){
        yield return new WaitUntil(volumeIsZero);
        while (audioS.volume < 0.6f){
            audioS.volume += 0.5f * Time.deltaTime;
            yield return null;
        }
        audioS.volume = 0.6f;
    }

    IEnumerator DiminuiSom(){
        yield return new WaitUntil(volumeIsZeroPointSix);
        while (audioS.volume > 0f){
            audioS.volume -= 0.5f * Time.deltaTime;
            yield return null;
        }
        audioS.volume = 0f;
    }

    private bool volumeIsZero(){
        if(audioS.volume == 0f){
            return true;
        }
        else{
            return false;
        }
    }

    private bool volumeIsZeroPointSix(){
        if(audioS.volume == 0.6f){
            return true;
        }
        else{
            return false;
        }
    }
}