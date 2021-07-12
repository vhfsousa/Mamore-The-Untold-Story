using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialEToInteractMagnifyingGlass : MonoBehaviour
{
    [SerializeField] private GameObject e;
    [SerializeField] private Animator eAnimator;
    
    void Start()
    {
        eAnimator = e.GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)){
            eAnimator.SetBool("apertouE", true);
        }
    }

    void OnTriggerEnter(Collider col){
        if(col.gameObject.CompareTag("Player")){
            EFunction();
        }
    }

    void EFunction(){
        eAnimator.Play("EToInteractMagnifyingGlass");
    }
}