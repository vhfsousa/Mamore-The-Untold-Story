using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    [SerializeField] private string sceneName;
    [SerializeField] private GameObject estruturaMenu;
    [SerializeField] private Button continueButton;
    [SerializeField] private GameObject confirmationNewGame;
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private Color lowAlphaColor;
    [SerializeField] private Color solidColor;

    void Update(){
        if(PlayerPrefs.GetInt("Pontuacao") == 0){
            continueButton.interactable = false;
            continueButton.image.color = lowAlphaColor;
        }
        
        if(PlayerPrefs.GetInt("Pontuacao") > 0){
            continueButton.interactable = true;
            continueButton.image.color = solidColor;
        }
    }

    public void NewGamePressed(){
        if (PlayerPrefs.GetInt("Pontuacao") == 0){
            StartButton(sceneName);
        }
        if (PlayerPrefs.GetInt("Pontuacao") > 0){
            ConfirmScreen();
        }
    }

    private void StartButton(string sceneName){
        //Zerar as fotos
        string path = Path.Combine(Application.dataPath , "Screenshots");
        if(Directory.Exists(path))
        {
            Directory.Delete(path, true);
        }
        if(!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        estruturaMenu.gameObject.GetComponent<AudioSource>().enabled = false;

        //ResetarSaves
        PlayerPrefs.SetInt("Pontuacao", 0);
        PlayerPrefs.SetFloat("PlayerX", 461.26f);
        PlayerPrefs.SetFloat("PlayerY", 156.9002f);
        PlayerPrefs.SetFloat("PlayerZ", -327.98f);
        PlayerPrefs.SetFloat("Chave1", 0);
        PlayerPrefs.SetFloat("Chave2", 0);
        PlayerPrefs.SetFloat("PistaEstacao", 0);
        PlayerPrefs.SetFloat("PistaVagao", 0);
        PlayerPrefs.SetFloat("PistaCaverna", 0);
        PlayerPrefs.SetFloat("PistaTrilho", 0);
        PlayerPrefs.SetFloat("PistaFogueira", 0);
        PlayerPrefs.SetFloat("PistaEstabulo", 0);
        PlayerPrefs.SetFloat("PistaLatex", 0);
        PlayerPrefs.SetFloat("PistaBarraca", 0);

        //Dá load na cena
        StartCoroutine(LoadAsynchronously(sceneName));
    }

    private void ConfirmScreen(){
        confirmationNewGame.SetActive(true);
    }

    //Couroutine Loading
    IEnumerator LoadAsynchronously (string sceneName)
    {
        loadingScreen.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        while (!operation.isDone)
        {
            Debug.Log(operation.progress);
            yield return null;
        }
    }
}