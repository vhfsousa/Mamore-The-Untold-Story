using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class ResetDayButton : MonoBehaviour
{
    [SerializeField] private AudioSource somMusica;
    [SerializeField] private AudioSource falaInicialQuill;
    [SerializeField] private GameObject loadingStructure;
    [SerializeField] private GameObject menuStructure;
    [SerializeField] private GameObject player;
    [SerializeField] private string sceneName;

    public void RecarregarCena()
    {
        menuStructure.GetComponent<Menu>().menuActive = false;
        somMusica.enabled = false;
        falaInicialQuill.enabled = false;
        player.GetComponent<Player>().enabled = false;
        PlayerPrefs.SetFloat("PlayerX", 461.26f);
        PlayerPrefs.SetFloat("PlayerY", 156.9002f);
        PlayerPrefs.SetFloat("PlayerZ", -327.98f);
        loadingStructure.SetActive(true);
        Invoke("LoadAsynchronously", 3f);
    }
    private void LoadAsynchronously()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
    }
}