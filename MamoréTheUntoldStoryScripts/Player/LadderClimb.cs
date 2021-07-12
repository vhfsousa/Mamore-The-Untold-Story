using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderClimb : MonoBehaviour
{
    public Transform playerController;
    bool isClimbing;
    public float alturaEscada;
    public Player playerInput;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        if(Input.GetKey(KeyCode.W) && isClimbing)
        {
            playerController.transform.localPosition += Vector3.up / alturaEscada;
        }
        if(Input.GetKey(KeyCode.S) && isClimbing)
        {
            playerController.transform.localPosition += Vector3.up * -1 / alturaEscada;
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Ladder")
        {
            isClimbing = true;
            playerInput.enabled = false;
            playerInput.velocidade = playerInput.velAndar;
        }
        if(col.gameObject.tag == "Safe")
        {
            playerInput.enabled = true;
        }
    }
    private void OnTriggerExit(Collider col)
    {   
        if(col.gameObject.tag == "Ladder")
        {
            isClimbing = false;
            playerInput.enabled = true;
        }
    }
}
