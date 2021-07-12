using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTakePhotoWithMouse1 : MonoBehaviour
{
    [SerializeField] private GameObject mouse1;
    [SerializeField] private Animator mouse1Animator;
    
    void Start()
    {
        mouse1Animator = mouse1.GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0)){
            mouse1Animator.SetBool("apertouMouse1", true);
        }
    }

    void OnTriggerEnter(Collider col){
        if(col.gameObject.CompareTag("Player")){
            Mouse1Function();
        }
    }

    void Mouse1Function(){
        mouse1Animator.Play("TakePhotoWithMouse1");
    }
}