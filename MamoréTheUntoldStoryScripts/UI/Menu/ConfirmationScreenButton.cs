using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmationScreenButton : MonoBehaviour
{
    public GameObject telaConfirmacao;

    public void AbreTelaConfirmacao(){
        telaConfirmacao.SetActive(true);
    }
}
