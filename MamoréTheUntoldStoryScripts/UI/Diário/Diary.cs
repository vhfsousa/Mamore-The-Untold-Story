using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diary : MonoBehaviour
{
    [SerializeField] private GameObject diaryController;
    [SerializeField] private GameObject[] paginas;
    [SerializeField] private AudioSource audioDiario;
    [SerializeField] private AudioClip trocarPagina;
    [SerializeField] private int numeroPagina;

    void Start()
    {
        audioDiario = GetComponent<AudioSource>();
        numeroPagina = 0;
        paginas[1].SetActive(false);
        paginas[2].SetActive(false);
        paginas[3].SetActive(false);
        paginas[4].SetActive(false);
        paginas[5].SetActive(false);
    }

    void AdvancePage(){
        if(numeroPagina != 5){
            audioDiario.PlayOneShot(trocarPagina);
        }
        paginas[numeroPagina].SetActive(false);
        numeroPagina +=1;
    }

    void ReturnPage(){
        if(numeroPagina != 0){
            audioDiario.PlayOneShot(trocarPagina);
        }
        paginas[numeroPagina].SetActive(false);
        numeroPagina -= 1;
    }

    void Update()
    {
        //Funções do diário
        if(diaryController.GetComponent<DiaryController>().diaryIsOpen == true){
            if(Input.GetKeyDown(KeyCode.E)){
            AdvancePage();
            }

            if(Input.GetKeyDown(KeyCode.Q)){
            ReturnPage();
            }
        }
        
        //Seguraça para não bugar o diário
        if(numeroPagina < 0){
            numeroPagina = 0;
        }else if(numeroPagina > 5){
            numeroPagina = 5;
        }

        //Ativa a página "atual" do diário;
        paginas[numeroPagina].SetActive(true);
    }
}