using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public bool menuActive;
    [SerializeField] private GameObject menuStucture;
    //Verificar se tem algum objeto aberto para não abrir o menu
    [SerializeField] private GameObject InspectRaycast;

    void Start()
    {
        menuActive = false;
    }
    
    void Update()
    {
        //Aparece ou Desaparece a interface do menu
        if(menuActive == false){
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            menuStucture.SetActive(false);
        }

        if(menuActive == true){
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            menuStucture.SetActive(true);
        }

        //Liberação de abrir o menu
        if(menuActive == false && InspectRaycast.GetComponent<InspectRaycast>().inspectedObjectActive == false && Input.GetKeyDown(KeyCode.Escape)){
            menuActive = true;
        }
        else if(menuActive == true && Input.GetKeyDown(KeyCode.Escape)){
            menuActive = false;
        }
    }
}