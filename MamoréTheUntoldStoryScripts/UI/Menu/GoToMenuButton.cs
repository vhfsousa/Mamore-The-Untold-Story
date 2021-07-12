using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMenuButton : MonoBehaviour
{
    [SerializeField] private AudioSource somMusica;
    [SerializeField] private AudioSource falaInicialQuill;
    [SerializeField] private GameObject loadingStructure;
    [SerializeField] private GameObject menuStructure;
    [SerializeField] private GameObject player;
    [SerializeField] bool isInMenu;
    [SerializeField] private string sceneName;

    public void GoToMenu(){
        if(isInMenu == false)
        {
            menuStructure.GetComponent<Menu>().menuActive = false;
            falaInicialQuill.enabled = false;
            player.GetComponent<Player>().enabled = false;
            PlayerPrefs.SetFloat("PlayerX", player.transform.position.x);
            PlayerPrefs.SetFloat("PlayerY", player.transform.position.y);
            PlayerPrefs.SetFloat("PlayerZ", player.transform.position.z);
        }
        somMusica.enabled = false;
        loadingStructure.SetActive(true);
        Invoke("LoadAsynchronously", 3f);
    }

    private void LoadAsynchronously()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
    }
}