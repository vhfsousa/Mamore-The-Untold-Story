using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.IO;

public class CemeraRaycast : MonoBehaviour
{
    private AudioSource audioCamera;
    [SerializeField] private Animator flashAnim;
    [SerializeField] private LayerMask interactCameraLayer;
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject player;
    [SerializeField] private int raycastDist;
    [SerializeField] private GameObject clueController;
    [SerializeField] private GameObject[] colliders;
    public Image[] imagens;
    [SerializeField] private Image cameraCrosshair;
    public Camera _camera;
    public Texture2D _screenShot;
    int resWidth = 1920;
    int resHeight = 1080;
    private bool isCrosshairActive;
    private bool umaVez;
    public string local;
    public Sprite tempSprite;
    public AudioClip tirarFotoSom;
    void Start()
    {
        audioCamera = GetComponent<AudioSource>();
        cameraCrosshair.gameObject.SetActive(false);
    }

    void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        if(Physics.Raycast(transform.position, fwd, out hit, raycastDist, interactCameraLayer.value))
        {
            if(hit.collider.CompareTag("CameraTag"))
            {
                if(!umaVez)
                {
                    CrosshairChange(true);
                }
                isCrosshairActive = true;
                umaVez = true;
                if(menu.GetComponent<Menu>().menuActive == false)
                {
                    if(player.GetComponent<Player>().segurandoCam == true && Input.GetMouseButtonDown(0))
                    {
                        flashAnim.Play("Flash");
                        StartCoroutine(TakeScreenShot());
                        audioCamera.PlayOneShot(tirarFotoSom);
                    }
                }
            }
        }
        else
        {
            if(isCrosshairActive)
            {
                CrosshairChange(false);
                umaVez = false;
            }
            if(player.GetComponent<Player>().segurandoCam == true && Input.GetMouseButtonDown(0))
            {
                Debug.Log("Sem foto");
            }
        }

        if(colliders[0].GetComponent<AreaColliders>().podeFotografar == true)
        {
            local = "estacao";
        }
        if(colliders[1].GetComponent<AreaColliders>().podeFotografar == true)
        {
            local = "trem_caido";
        }
        if(colliders[2].GetComponent<AreaColliders>().podeFotografar == true)
        {
            local = "caverna";
        }
        if(colliders[3].GetComponent<AreaColliders>().podeFotografar == true)
        {
            local = "armazem_trilho";
        }
        if(colliders[4].GetComponent<AreaColliders>().podeFotografar == true)
        {
            local = "fogueira";
        }
        if(colliders[5].GetComponent<AreaColliders>().podeFotografar == true)
        {
            local = "estabulo";
        }
        if(colliders[6].GetComponent<AreaColliders>().podeFotografar == true)
        {
            local = "armazem_latex";
        }
        if(colliders[7].GetComponent<AreaColliders>().podeFotografar == true)
        {
            local = "barraca_regis";
        }
    }
    void CrosshairChange(bool on)
    {
        if(on && !umaVez)
        {
            cameraCrosshair.gameObject.SetActive(true);
        }
        else
        {
            cameraCrosshair.gameObject.SetActive(false);
            isCrosshairActive = false;
        }
    }
    public IEnumerator TakeScreenShot()
    {
        yield return new WaitForEndOfFrame();

        RenderTexture rt = new RenderTexture(resWidth, resHeight, 24);
        _camera.targetTexture = rt;
        _screenShot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
        _camera.Render();
        RenderTexture.active = rt;
        _screenShot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
        _screenShot.Apply();
        _camera.targetTexture = null;
        RenderTexture.active = null;
        Destroy(rt);

        string filename = ScreenShotName();

        byte[] bytes = _screenShot.EncodeToPNG();
        System.IO.File.WriteAllBytes(filename, bytes);

        Debug.Log(string.Format("Took screenshot to: {0}", filename));

        tempSprite = Sprite.Create(_screenShot, new Rect(0, 0, resWidth, resHeight), new Vector2(0, 0));
        
        if(colliders[0].GetComponent<AreaColliders>().podeFotografar == true)
        {
            if(imagens[0].sprite == null || imagens[0].sprite != null){
                clueController.GetComponent<ClueController>().PontuouFoto0();
            }
            imagens[0].sprite = tempSprite;
            clueController.GetComponent<ClueController>().pontuou[0] = true;
            colliders[0].GetComponent<AreaColliders>().gameObject.SetActive(false);
            colliders[0].GetComponent<BoxCollider>().enabled = false;
            colliders[0].GetComponent<AreaColliders>().podeFotografar = false;
            PlayerPrefs.SetFloat("PistaEstacao", 1);

        }
        if(colliders[1].GetComponent<AreaColliders>().podeFotografar == true)
        {
            if(imagens[1].sprite == null || imagens[1].sprite != null){
                clueController.GetComponent<ClueController>().PontuouFoto1();
            }
            imagens[1].sprite = tempSprite;
            clueController.GetComponent<ClueController>().pontuou[1] = true;
            colliders[1].GetComponent<BoxCollider>().enabled = false;
            colliders[1].GetComponent<AreaColliders>().podeFotografar = false;
            PlayerPrefs.SetFloat("PistaVagao", 1);
        }
        if(colliders[2].GetComponent<AreaColliders>().podeFotografar == true)
        {
            if(imagens[2].sprite == null || imagens[2].sprite != null){
                clueController.GetComponent<ClueController>().PontuouFoto2();
            }
            imagens[2].sprite = tempSprite;
            clueController.GetComponent<ClueController>().pontuou[2] = true;
            colliders[2].GetComponent<BoxCollider>().enabled = false;
            colliders[2].GetComponent<AreaColliders>().podeFotografar = false;
            PlayerPrefs.SetFloat("PistaCaverna", 1);
        }
        if(colliders[3].GetComponent<AreaColliders>().podeFotografar == true)
        {
            if(imagens[3].sprite == null || imagens[3].sprite != null){
                clueController.GetComponent<ClueController>().PontuouFoto3();
            }
            imagens[3].sprite = tempSprite;
            clueController.GetComponent<ClueController>().pontuou[3] = true;
            colliders[3].GetComponent<BoxCollider>().enabled = false;
            colliders[3].GetComponent<AreaColliders>().podeFotografar = false;
            PlayerPrefs.SetFloat("PistaCaverna", 1);
        }
        if(colliders[4].GetComponent<AreaColliders>().podeFotografar == true)
        {
            if(imagens[4].sprite == null || imagens[4].sprite != null){
                clueController.GetComponent<ClueController>().PontuouFoto4();
            }
            imagens[4].sprite = tempSprite;
            clueController.GetComponent<ClueController>().pontuou[4] = true;
            colliders[4].GetComponent<BoxCollider>().enabled = false;
            colliders[4].GetComponent<AreaColliders>().podeFotografar = false;
            PlayerPrefs.SetFloat("PistaTrilho", 1);
        }
        if(colliders[5].GetComponent<AreaColliders>().podeFotografar == true)
        {
            if(imagens[5].sprite == null || imagens[5].sprite != null){
                clueController.GetComponent<ClueController>().PontuouFoto5();
            }
            imagens[5].sprite = tempSprite;
            clueController.GetComponent<ClueController>().pontuou[5] = true;
            colliders[5].GetComponent<BoxCollider>().enabled = false;
            colliders[5].GetComponent<AreaColliders>().podeFotografar = false;
            PlayerPrefs.SetFloat("PistaFogueira", 1);
        }
        if(colliders[6].GetComponent<AreaColliders>().podeFotografar == true)
        {
            if(imagens[6].sprite == null || imagens[6].sprite != null){
                clueController.GetComponent<ClueController>().PontuouFoto6();
            }
            imagens[6].sprite = tempSprite;
            clueController.GetComponent<ClueController>().pontuou[6] = true;
            colliders[6].GetComponent<BoxCollider>().enabled = false;
            colliders[6].GetComponent<AreaColliders>().podeFotografar = false;
            PlayerPrefs.SetFloat("PistaLatex", 1);
        }
        if(colliders[7].GetComponent<AreaColliders>().podeFotografar == true)
        {
            if(imagens[7].sprite == null || imagens[7].sprite != null){
                clueController.GetComponent<ClueController>().PontuouFoto7();
            }
            imagens[7].sprite = tempSprite;
            clueController.GetComponent<ClueController>().pontuou[7] = true;
            colliders[7].GetComponent<BoxCollider>().enabled = false;
            colliders[7].GetComponent<AreaColliders>().podeFotografar = false;
            PlayerPrefs.SetFloat("PistaBarraca", 1);
        }
    }
    public string ScreenShotName()
    {
        return string.Format("{0}/Screenshots/foto_{1}.png", Application.dataPath, local);
    }
}
