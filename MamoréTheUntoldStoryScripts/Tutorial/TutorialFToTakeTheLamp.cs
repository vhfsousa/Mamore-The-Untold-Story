using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialFToTakeTheLamp : MonoBehaviour
{
    [SerializeField] private GameObject f;
    [SerializeField] private Animator fAnimator;
    
    void Start()
    {
        fAnimator = f.GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F)){
            fAnimator.SetBool("apertouF", true);
        }
    }

    void OnTriggerEnter(Collider col){
        if(col.gameObject.CompareTag("Player")){
            FFunction();
        }
    }

    void FFunction(){
        fAnimator.Play("FToTakeTheLamp");
    }
}