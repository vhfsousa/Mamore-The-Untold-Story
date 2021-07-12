using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocalNamesColliders : MonoBehaviour
{
    [SerializeField] private GameObject localNameUI;
    [SerializeField] private Animator localNameAnimator;
    [SerializeField] private string localNameAnimation;

    void Start(){
        localNameAnimator = localNameUI.GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider col){
        localNameAnimator.Play(localNameAnimation);
    }
}