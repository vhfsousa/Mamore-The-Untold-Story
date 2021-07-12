using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoBackButton : MonoBehaviour
{
    public GameObject window;
    
    public void GoBack(){
        window.SetActive(false);
    }
}