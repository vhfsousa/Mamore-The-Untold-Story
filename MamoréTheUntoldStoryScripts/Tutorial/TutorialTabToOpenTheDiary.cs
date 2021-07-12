using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTabToOpenTheDiary : MonoBehaviour
{
    [SerializeField] private GameObject tab;
    [SerializeField] private Animator tabAnimator;
    
    void Start()
    {
        tabAnimator = tab.GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab)){
            tabAnimator.SetBool("apertouTab", true);
        }
    }

    void OnTriggerEnter(Collider col){
        if(col.gameObject.CompareTag("Player")){
            TabFunction();
        }
    }

    void TabFunction(){
        tabAnimator.Play("TabToOpenTheDiary");
    }
}