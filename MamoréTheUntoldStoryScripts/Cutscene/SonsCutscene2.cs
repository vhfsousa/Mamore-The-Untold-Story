using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SonsCutscene2 : MonoBehaviour
{
    [SerializeField] private AudioSource audioS;
    [SerializeField] private AudioSource audioSourceMusica;
    [SerializeField] private AudioClip discandoTelefone;
    [SerializeField] private AudioClip quill4;
    [SerializeField] private AudioClip joselyn5;
    [SerializeField] private AudioClip quill5;
    [SerializeField] private AudioClip joselyn6;
    [SerializeField] private AudioClip quill6;
    [SerializeField] private AudioClip telefoneDesligando;
    [SerializeField] private GameObject loadingStructure;
    [SerializeField] private Text textoLegenda;
    [SerializeField] private Font joselynFont;
    [SerializeField] private Font quillFont;
    [SerializeField] private string sceneName;

    void Start()
    {
        Invoke("DiscandoTelefone", 3.09f);
        Invoke("Quill4", 5.19f);
        Invoke("Joselyn5", 12.15f);
        Invoke("Quill5", 15.5f);
        Invoke("Joselyn6", 22.15f);
        Invoke("Quill6", 26.09f);
        Invoke("TelefoneDesligando", 68.18f);
        Invoke("CreditsScene", 72f);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            CreditsScene();
        }
    }

    void DiscandoTelefone(){
        audioS.PlayOneShot(discandoTelefone);
    }

    void Quill4(){
        audioS.PlayOneShot(quill4);
        textoLegenda.font = quillFont;
        textoLegenda.fontSize = 35;
        textoLegenda.text = "Detective Quill: Ms. Cubikks, I've discovered the real cause of death of your father.";
    }

    void Joselyn5(){
        audioS.PlayOneShot(joselyn5);
        textoLegenda.font = joselynFont;
        textoLegenda.fontSize = 30;
        textoLegenda.text = "Joselyn Cubikks: Please tell me! I need to know!";
    }

    void Quill5(){
        audioS.PlayOneShot(quill5);
        textoLegenda.font = quillFont;
        textoLegenda.fontSize = 35;
        textoLegenda.text = "Detective Quill: Ok, I can tell you by phone, but I think you should come to my office to find out all the facts.";
    }

    void Joselyn6(){
        audioS.PlayOneShot(joselyn6);
        textoLegenda.font = joselynFont;
        textoLegenda.fontSize = 30;
        textoLegenda.text = "Joselyn Cubikks: I will, but please, just tell me now!";
    }

    void Quill6(){
        audioS.PlayOneShot(quill6);
        textoLegenda.font = quillFont;
        textoLegenda.fontSize = 35;
        textoLegenda.text = "Detective Quill: Your father has been murdered on account of Christoff who pretended to be a friend of Regis, but he actually framed him for a crime he didn't commit. Christoff had stolen latex and when he was going to be caught, he put the latex in Regis' chest who was discovered and killed.";
        Invoke("TrocarTextoQuill", 18.27f);
        Invoke("DesabilitarLegenda", 38.22f);
    }

    void TrocarTextoQuill(){
        textoLegenda.text = "Christoff noticed that Stainovick had seen the crime, killing him and leaving his body in the cave that your father and Christoff had visited the previous days. Regis confidence in Christoff killed him, your father was an innocent man who tried to help and was murdered by that.";
    }

    void TelefoneDesligando(){
        audioS.PlayOneShot(telefoneDesligando);
    }

    void DesabilitarLegenda(){
        textoLegenda.text = "";
    }

    void CreditsScene(){
        audioSourceMusica.enabled = false;
        audioS.enabled = false;
        loadingStructure.SetActive(true);
        StartCoroutine(LoadAsynchronously(sceneName));
    }

    IEnumerator LoadAsynchronously (string sceneName)
    {
        yield return new WaitForSeconds(3);
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        while (!operation.isDone)
        {
            Debug.Log(operation.progress);
            yield return null;
        }
    }
}