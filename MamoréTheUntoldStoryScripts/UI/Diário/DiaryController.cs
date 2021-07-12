using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaryController : MonoBehaviour
{
    public bool diaryIsOpen;
    [SerializeField] private GameObject diary;
    [SerializeField] private AudioSource somDiario;
    [SerializeField] private AudioClip pegandoDiario;

    void Start()
    {
        diaryIsOpen = false;
        somDiario = GetComponent<AudioSource>();
    }

    void Update()
    {
        //Aparece ou Desaparece a interface do diário
        if(diaryIsOpen == false){
            diary.SetActive(false);
        }
        else if(diaryIsOpen == true){
            diary.SetActive(true);
        }

        //Liberação de abrir o diário
        if(diaryIsOpen == false && Input.GetKeyDown(KeyCode.Tab)){
            somDiario.PlayOneShot(pegandoDiario);
            diaryIsOpen = true;
        }
        else if(diaryIsOpen == true && Input.GetKeyDown(KeyCode.Tab)){
            somDiario.PlayOneShot(pegandoDiario);
            diaryIsOpen = false;
        }
    }
}