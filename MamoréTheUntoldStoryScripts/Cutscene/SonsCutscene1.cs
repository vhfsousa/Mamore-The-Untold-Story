using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SonsCutscene1 : MonoBehaviour
{
    [SerializeField] private AudioSource audioS;
    [SerializeField] private AudioSource audioSourceMusica;
    [SerializeField] private AudioClip telefoneTocando;
    [SerializeField] private AudioClip persiana;
    [SerializeField] private AudioClip andadinhaCadeira;
    [SerializeField] private AudioClip puxouCadeira;
    [SerializeField] private AudioClip sentar;
    [SerializeField] private AudioClip voltarCadeira;
    [SerializeField] private AudioClip pegarTelefone;
    [SerializeField] private AudioClip joselyn1;
    [SerializeField] private AudioClip quill1;
    [SerializeField] private AudioClip joselyn2;
    [SerializeField] private AudioClip quill2;
    [SerializeField] private AudioClip joselyn3;
    [SerializeField] private AudioClip quill3;
    [SerializeField] private AudioClip joselyn4;
    [SerializeField] private AudioClip puxarGaveta;
    [SerializeField] private AudioClip pegouDiario;
    [SerializeField] private AudioClip fechouGaveta;
    [SerializeField] private AudioClip desligaTelefone;
    [SerializeField] private GameObject loadingStructure;
    [SerializeField] private Text textoLegenda;
    [SerializeField] private Font joselynFont;
    [SerializeField] private Font quillFont;
    [SerializeField] private string sceneName;

    void Start()
    {
        Invoke("SomTelefone", 0f);
        Invoke("Persiana", 2f);
        Invoke("AndadinhaCadeira", 4.1f);
        Invoke("PuxouCadeira", 6.05f);
        Invoke("Sentar", 9.05f);
        Invoke("VoltarCadeira", 10.07f);
        Invoke("PegarTelefone", 13.02f);
        Invoke("Joselyn1", 14.01f);
        Invoke("Quill1", 18.04f);
        Invoke("Joselyn2", 21.03f);
        Invoke("Quill2", 37.05f);
        Invoke("Joselyn3", 41.1f);
        Invoke("Quill3", 53.01f);
        Invoke("Joselyn4", 61.05f);
        Invoke("PuxarGaveta", 59.03f);
        Invoke("PegouDiario", 65.03f);
        Invoke("FechouGaveta", 68.1f);
        Invoke("DesligaTelefone", 78f);
        Invoke("GameScene", 80f);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            GameScene();
        }
    }
    
    void SomTelefone(){
        audioS.PlayOneShot(telefoneTocando);
    }

    void Persiana(){
        audioS.PlayOneShot(persiana);
    }

    void AndadinhaCadeira(){
        audioS.PlayOneShot(andadinhaCadeira);
    }

    void PuxouCadeira(){
        audioS.PlayOneShot(puxouCadeira);
    }

    void Sentar(){
        audioS.PlayOneShot(sentar);
    }

    void VoltarCadeira(){
        audioS.PlayOneShot(voltarCadeira);
    }

    void PegarTelefone(){
        audioS.PlayOneShot(pegarTelefone);
    }

    void Joselyn1(){
        audioS.PlayOneShot(joselyn1);
        textoLegenda.font = joselynFont;
        textoLegenda.fontSize = 30;
        textoLegenda.text = "Joselyn Cubikks: Hello Mr. Quill, I need you to investigate a case.";
    }

    void Quill1(){
        audioS.PlayOneShot(quill1);
        textoLegenda.font = quillFont;
        textoLegenda.fontSize = 35;
        textoLegenda.text = "Detective Quill: Hello lady, what's this case about?";
    }

    void Joselyn2(){
        audioS.PlayOneShot(joselyn2);
        textoLegenda.font = joselynFont;
        textoLegenda.fontSize = 30;
        textoLegenda.text = "Joselyn Cubikks: My name is Joselyn Cubikks and the case is about my father, Regis. He had worked in the construction of Madeira-Mamoré Railroad in Brazil and had died during the job. Many workers had died in there but the company had never told the family how each worker had died.";
    }

    void Quill2(){
        audioS.PlayOneShot(quill2);
        textoLegenda.font = quillFont;
        textoLegenda.fontSize = 35;
        textoLegenda.text = "Detective Quill: So do you want me to investigate the place and find something about your dad?";
    }

    void Joselyn3(){
        audioS.PlayOneShot(joselyn3);
        textoLegenda.font = joselynFont;
        textoLegenda.fontSize = 30;
        textoLegenda.text = "Joselyn Cubikks: Something like that. The company gave me a diary which was signed by my dad, I've sent it to you to help in this investigation. Please go there and discover what happened to my father.";
    }

    void Quill3(){
        audioS.PlayOneShot(quill3);
        textoLegenda.font = quillFont;
        textoLegenda.fontSize = 35;
        textoLegenda.text = "Detective Quill: Ok, I am on it, and I'll find the true cause of death of Regis Cubikks. See you son, bye.";
    }

    void Joselyn4(){
        audioS.PlayOneShot(joselyn4);
        textoLegenda.font = joselynFont;
        textoLegenda.fontSize = 30;
        textoLegenda.text = "Joselyn Cubikks: Goodbye and good luck Mr. Quill.";
        Invoke("DesabilitarLegenda", 3.01f);
    }

    void PuxarGaveta(){
        audioS.PlayOneShot(puxarGaveta);
    }

    void PegouDiario(){
        audioS.PlayOneShot(pegouDiario);
    }

    void FechouGaveta(){
        audioS.PlayOneShot(fechouGaveta);
    }

    void DesligaTelefone(){
        audioS.PlayOneShot(desligaTelefone);
    }

    void DesabilitarLegenda(){
        textoLegenda.text = "";
    }
    
    void GameScene(){
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