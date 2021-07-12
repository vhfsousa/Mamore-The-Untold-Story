using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCTRLToCrouch : MonoBehaviour
{
    [SerializeField] private GameObject ctrl;
    [SerializeField] private Animator ctrlAnimator;
    
    void Start()
    {
        ctrlAnimator = ctrl.GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftControl)){
            ctrlAnimator.SetBool("apertouCtrl", true);
        }
    }

    void OnTriggerEnter(Collider col){
        if(col.gameObject.CompareTag("Player")){
            CTRLFunction();
        }
    }

    void CTRLFunction(){
        ctrlAnimator.Play("CTRLToCrouch");
    }
}
