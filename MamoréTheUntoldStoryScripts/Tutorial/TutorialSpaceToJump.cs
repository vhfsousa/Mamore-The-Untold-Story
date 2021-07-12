using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSpaceToJump : MonoBehaviour
{
    [SerializeField] private GameObject space;
    [SerializeField] private Animator spaceAnimator;
    
    void Start()
    {
        spaceAnimator = space.GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            spaceAnimator.SetBool("apertouSpace", true);
        }
    }

    void OnTriggerEnter(Collider col){
        if(col.gameObject.CompareTag("Player")){
            SpaceFunction();
        }
    }

    void SpaceFunction(){
        spaceAnimator.Play("SpaceToJump");
    }
}