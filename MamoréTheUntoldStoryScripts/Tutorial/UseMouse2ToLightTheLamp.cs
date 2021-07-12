using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseMouse2ToLightTheLamp : MonoBehaviour
{
    [SerializeField] private GameObject mouse2;
    [SerializeField] private Animator mouse2Animator;

    void Start()
    {
        mouse2Animator = mouse2.GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse1)){
            mouse2Animator.SetBool("apertouMouse2", true);
        }
    }

    void OnTriggerEnter(Collider col){
        if(col.gameObject.CompareTag("Player")){
            Mouse2Function();
        }
    }

    void Mouse2Function(){
        mouse2Animator.Play("UseMouse2ToLightTheLamp");
    }
}