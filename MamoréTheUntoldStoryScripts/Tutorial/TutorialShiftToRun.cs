using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialShiftToRun : MonoBehaviour
{
    [SerializeField] private GameObject shift;
    [SerializeField] private Animator shiftAnimator;
    
    void Start()
    {
        shiftAnimator = shift.GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift)){
            shiftAnimator.SetBool("apertouShift", true);
        }
    }

    void OnTriggerEnter(Collider col){
        if(col.gameObject.CompareTag("Player")){
            ShiftFunction();
        }
    }

    void ShiftFunction(){
        shiftAnimator.Play("ShiftToRun");
    }
}
