using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.IO;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private float mouseSensibility;
    [SerializeField] private float volumeGeral;
    [SerializeField] private float playerX;
    [SerializeField] private float playerY;
    [SerializeField] private float playerZ;
    [SerializeField] private int pontuacao;
    [SerializeField] private bool terminouJogo;
    [SerializeField] public GameObject mouseLook;
    [SerializeField] private Text volumeText;
    [SerializeField] private Text sensibilityText;
    [SerializeField] private Image diaryNotification;
    [SerializeField] private AudioMixer mixerGeral;
    [SerializeField] private AudioSource somMusica;
    [SerializeField] private GameObject loadingStructure;
    [SerializeField] private string sceneName;
    [SerializeField] private Text textoLegenda;
    [SerializeField] private AudioSource somLegenda;
    [SerializeField] private AudioClip quillArriving;
    [SerializeField] private AudioClip quillLeaving;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject chaveCobre;
    [SerializeField] private GameObject chavePrata;
    [SerializeField] private GameObject objChaveCobre;
    [SerializeField] private GameObject objChavePrata;
    [SerializeField] private GameObject colliderEstacao;
    [SerializeField] private GameObject colliderVagao;
    [SerializeField] private GameObject colliderCaverna;
    [SerializeField] private GameObject colliderTrilho;
    [SerializeField] private GameObject colliderFogueira;
    [SerializeField] private GameObject colliderEstabulo;
    [SerializeField] private GameObject colliderLatex;
    [SerializeField] private GameObject colliderBarracaRegis;
    [SerializeField] private GameObject portaEstacao;
    [SerializeField] private GameObject portaMedica;
    public static bool[] chaves = new bool[13];

    void Start(){
        //Saves
        pontuacao = PlayerPrefs.GetInt("Pontuacao");
        playerX = PlayerPrefs.GetFloat("PlayerX");
        playerY = PlayerPrefs.GetFloat("PlayerY");
        playerZ = PlayerPrefs.GetFloat("PlayerZ");
        player.transform.position = new Vector3 (playerX, playerY, playerZ);

        //Saves Chaves e Colliders
        if(PlayerPrefs.GetFloat("Chave1") == 1){
            chaves[portaEstacao.GetComponent<DoorController>().index = 0] = true;
            objChaveCobre.SetActive(false);
            chaveCobre.SetActive(true);
        }else if(PlayerPrefs.GetFloat("Chave1") == 0){
            objChaveCobre.SetActive(true);
            chaveCobre.SetActive(false);
        }

        if(PlayerPrefs.GetFloat("Chave2") == 1){
            chaves[portaMedica.GetComponent<DoorController>().index = 1] = true;
            objChavePrata.SetActive(false);
            chavePrata.SetActive(true);
        }else if(PlayerPrefs.GetFloat("Chave2") == 0){
            objChavePrata.SetActive(true);
            chavePrata.SetActive(false);
        }
        
        if(PlayerPrefs.GetFloat("PistaEstacao") == 1){
            colliderEstacao.GetComponent<AreaColliders>().podeFotografar = false;
            colliderEstacao.GetComponent<AreaColliders>().gameObject.SetActive(false);
        }else if(PlayerPrefs.GetFloat("PistaEstacao") == 0){
            colliderEstacao.GetComponent<AreaColliders>().gameObject.SetActive(true);
        }

        if(PlayerPrefs.GetFloat("PistaVagao") == 1){
            colliderVagao.GetComponent<AreaColliders>().podeFotografar = false;
            colliderVagao.GetComponent<AreaColliders>().gameObject.SetActive(false);
        }else if(PlayerPrefs.GetFloat("PistaVagao") == 0){
            colliderVagao.GetComponent<AreaColliders>().gameObject.SetActive(true);
        }

        if(PlayerPrefs.GetFloat("PistaCaverna") == 1){
            colliderCaverna.GetComponent<AreaColliders>().podeFotografar = false;
            colliderCaverna.GetComponent<AreaColliders>().gameObject.SetActive(false);
        }else if(PlayerPrefs.GetFloat("PistaCaverna") == 0){
            colliderCaverna.GetComponent<AreaColliders>().gameObject.SetActive(true);
        }

        if(PlayerPrefs.GetFloat("PistaTrilho") == 1){
            colliderTrilho.GetComponent<AreaColliders>().podeFotografar = false;
            colliderTrilho.GetComponent<AreaColliders>().gameObject.SetActive(false);
        }else if(PlayerPrefs.GetFloat("PistaTrilho") == 0){
            colliderTrilho.GetComponent<AreaColliders>().gameObject.SetActive(true);
        }

        if(PlayerPrefs.GetFloat("PistaFogueira") == 1){
            colliderFogueira.GetComponent<AreaColliders>().podeFotografar = false;
            colliderFogueira.GetComponent<AreaColliders>().gameObject.SetActive(false);
        }else if(PlayerPrefs.GetFloat("PistaFogueira") == 0){
            colliderFogueira.GetComponent<AreaColliders>().gameObject.SetActive(true);
        }

        if(PlayerPrefs.GetFloat("PistaEstabulo") == 1){
            colliderEstabulo.GetComponent<AreaColliders>().podeFotografar = false;
            colliderEstabulo.GetComponent<AreaColliders>().gameObject.SetActive(false);
        }else if(PlayerPrefs.GetFloat("PistaEstabulo") == 0){
            colliderEstabulo.GetComponent<AreaColliders>().gameObject.SetActive(true);
        }

        if(PlayerPrefs.GetFloat("PistaLatex") == 1){
            colliderLatex.GetComponent<AreaColliders>().podeFotografar = false;
            colliderLatex.GetComponent<AreaColliders>().gameObject.SetActive(false);
        }else if(PlayerPrefs.GetFloat("PistaLatex") == 0){
            colliderLatex.GetComponent<AreaColliders>().gameObject.SetActive(true);
        }

        if(PlayerPrefs.GetFloat("PistaBarraca") == 1){
            colliderBarracaRegis.GetComponent<AreaColliders>().podeFotografar = false;
            colliderBarracaRegis.GetComponent<AreaColliders>().gameObject.SetActive(false);
        }else if(PlayerPrefs.GetFloat("PistaBarraca") == 0){
            colliderBarracaRegis.GetComponent<AreaColliders>().gameObject.SetActive(true);
        }

        //Configs
        volumeGeral = PlayerPrefs.GetFloat("Volume");
        mouseSensibility = PlayerPrefs.GetFloat("Sensibilidade");
        
        mouseLook.gameObject.GetComponent<MouseLook>().mouseSense = mouseSensibility;
        diaryNotification.gameObject.SetActive(false);
        textoLegenda.text = "";
        Invoke("QuillArriving", 15f);
    }

    void Update(){
        Debug.Log(pontuacao);
        volumeText.text = (Mathf.RoundToInt(volumeGeral * 100)).ToString();
        sensibilityText.text = (mouseLook.gameObject.GetComponent<MouseLook>().mouseSense/1000).ToString();
        EndGame();

        if(Input.GetKeyDown(KeyCode.Tab)){
            if(diaryNotification.enabled == true){
                diaryNotification.gameObject.SetActive(false);
            }
        }
    }

    public void AumentaPonto(){
        diaryNotification.gameObject.SetActive(true);
        pontuacao += 1;
        PlayerPrefs.SetInt("Pontuacao", pontuacao);
    }

    public void AjustarVolume(float receivedVolume){
        volumeGeral = receivedVolume;
        PlayerPrefs.SetFloat("Volume", volumeGeral);
        mixerGeral.SetFloat("MasterVolume", Mathf.Log10(volumeGeral) * 20);
    }

    public void AjustarSensibilidade(float mSpeed){
        mouseSensibility = mSpeed * 1000;
        PlayerPrefs.SetFloat("Sensibilidade", mouseSensibility);
        mouseLook.gameObject.GetComponent<MouseLook>().mouseSense = mouseSensibility;
    }

    public void VSync(bool value){
        if(value == true){
            QualitySettings.vSyncCount = 2;
        }else if(value == false){
            QualitySettings.vSyncCount = 0;
        }
    }

    private void EndGame(){
        if(terminouJogo == false){
            if(pontuacao == 8){
                terminouJogo = true;
                Invoke("QuillLeaving", 5f);
                Invoke("GoToCutscene2", 16.55f);
            }
        }
    }

    private void QuillArriving(){
        somLegenda.PlayOneShot(quillArriving);
        textoLegenda.text = "Detective Quill: I need to find these clues but it may take all night long.";
        Invoke("DisablingQuillSubtitles", 4.41f);
    }

    private void QuillLeaving(){
        somLegenda.PlayOneShot(quillLeaving);
        textoLegenda.text = "Detective Quill: I’ve collected all the material which I need to conclude the investigation. I should go back to my office now.";
        Invoke("DisablingQuillSubtitles", 6.55f);
    }

        private void DisablingQuillSubtitles(){
        textoLegenda.text = "";
    }

    void GoToCutscene2(){
        somMusica.enabled = false;
        loadingStructure.SetActive(true);
        terminouJogo = false;
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