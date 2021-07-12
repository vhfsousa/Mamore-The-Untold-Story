using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QandEToUseTheDiary : MonoBehaviour
{
    [SerializeField] private GameObject qe;
    [SerializeField] private Animator qeAnimator;
    
    void Start()
    {
        qeAnimator = qe.GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.E)){
            qeAnimator.SetBool("apertouQE", true);
        }
    }

    void OnTriggerEnter(Collider col){
        if(col.gameObject.CompareTag("Player")){
            QEFunction();
        }
    }

    void QEFunction(){
        qeAnimator.Play("QandEToUseTheDiary");
    }
}