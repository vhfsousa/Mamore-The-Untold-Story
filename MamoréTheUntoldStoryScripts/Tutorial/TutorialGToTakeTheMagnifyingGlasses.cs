using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialGToTakeTheMagnifyingGlasses : MonoBehaviour
{
    [SerializeField] private GameObject g;
    [SerializeField] private Animator gAnimator;
    
    void Start()
    {
        gAnimator = g.GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G)){
            gAnimator.SetBool("apertouG", true);
        }
    }

    void OnTriggerEnter(Collider col){
        if(col.gameObject.CompareTag("Player")){
            GFunction();
        }
    }

    void GFunction(){
        gAnimator.Play("GToTakeTheMagnifyingGlasses");
    }
}