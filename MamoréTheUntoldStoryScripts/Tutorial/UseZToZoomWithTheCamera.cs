using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseZToZoomWithTheCamera : MonoBehaviour
{
    [SerializeField] private GameObject z;
    [SerializeField] private Animator zAnimator;

    void Start()
    {
        zAnimator = z.GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z)){
            zAnimator.SetBool("apertouZ", true);
        }
    }

    void OnTriggerEnter(Collider col){
        if(col.gameObject.CompareTag("Player")){
            ZFunction();
        }
    }

    void ZFunction(){
        zAnimator.Play("UseZToZoomWithTheCamera");
    }
}