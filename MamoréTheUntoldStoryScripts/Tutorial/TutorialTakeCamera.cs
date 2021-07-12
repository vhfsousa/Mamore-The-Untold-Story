using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTakeCamera : MonoBehaviour
{
    [SerializeField] private GameObject c;
    [SerializeField] private Animator cAnimator;
    
    void Start()
    {
        cAnimator = c.GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C)){
            cAnimator.SetBool("apertouC", true);
        }
    }

    void OnTriggerEnter(Collider col){
        if(col.gameObject.CompareTag("Player")){
            CFunction();
        }
    }

    void CFunction(){
        cAnimator.Play("TakeCamera");
    }
}
