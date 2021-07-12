using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private Animator portaAnim;
    private bool portaAberta = false;
    public bool semChave;
    public int index = -1;
    void Start()
    {
        if(semChave == true)
        {
            GameController.chaves[index] = true;
        }
    }
    public void PlayAnimation()
    {

        if(!portaAberta)
        {
            portaAnim.Play("DoorOpen", 0, 0.0f);
            portaAberta = true;
        }
        else
        {
            portaAnim.Play("DoorClose", 0, 0.0f);
            portaAberta = false;
        }
        
        

    }
}
