using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialAltToWalkSlowly : MonoBehaviour
{
    [SerializeField] private GameObject alt;
    [SerializeField] private Animator altAnimator;
    
    void Start()
    {
        altAnimator = alt.GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftAlt)){
            altAnimator.SetBool("apertouAlt", true);
        }
    }

    void OnTriggerEnter(Collider col){
        if(col.gameObject.CompareTag("Player")){
            AltFunction();
        }
    }

    void AltFunction(){
        altAnimator.Play("AltToWalkSlowly");
    }
}