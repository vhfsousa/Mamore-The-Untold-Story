using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CloseGameButton : MonoBehaviour
{
    [SerializeField] private GameObject player;
    public bool isInMenu;
    public void CloseGame(){
        if(isInMenu == false)
        {
            PlayerPrefs.SetFloat("PlayerX", player.transform.position.x);
            PlayerPrefs.SetFloat("PlayerY", player.transform.position.y);
            PlayerPrefs.SetFloat("PlayerZ", player.transform.position.z);
        }
        Application.Quit();
    }
}
