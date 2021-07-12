using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialWASD : MonoBehaviour
{
    [SerializeField] private GameObject wasd;
    [SerializeField] private Animator wasdAnimator;

    void Start()
    {
        wasdAnimator = wasd.GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W) ||Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D)){
            wasdAnimator.SetBool("apertouWASD", true);
        }
    }

    void OnTriggerEnter(Collider col){
        if(col.gameObject.CompareTag("Player")){
            WASDFunction();
        }
    }

    void WASDFunction(){
        wasdAnimator.Play("WASDToMove");
    }
}