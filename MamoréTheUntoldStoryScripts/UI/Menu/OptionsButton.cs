using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsButton : MonoBehaviour
{
    public GameObject optionsMenu;

    public void OpenOptions(){
        optionsMenu.SetActive(true);
    }
}