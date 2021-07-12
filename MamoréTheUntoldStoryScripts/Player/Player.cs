using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform cam;
    [SerializeField] private CharacterController controlador;
    [SerializeField] private AudioSource audioPlayer;
    [SerializeField] private AudioSource somAndar;
    [SerializeField] private Transform roofCheck;
    [SerializeField] private GameObject lanterna;
    [SerializeField] private GameObject playerCamera;
    [SerializeField] private GameObject lupa;
    [SerializeField] private GameObject folego;
    [SerializeField] private GameObject oilForLampRaycast;
    [SerializeField] private Transform ferramentas;
    [SerializeField] private GameObject luzLanterna;
    [SerializeField] private Animator cameraAnim;
    [SerializeField] private Animator lupaAnim;
    [SerializeField] private Animator lamparinaAnim;
    [SerializeField] private GameObject menu;
    [HideInInspector] public float velocidade;
    public float velAndar = 12;
    public float velCorrer = 18;
    public float velAbaixar = 6;
    public float velCaminhar = 8;
    public float gravidade = 10;
    public float pulo = 10;
    public float roofDist = 0.4f;
    private float contadorMovimentoCam;
    private float contadorIdleCam;
    private float contadorMovimentoFerramentas;
    private float contadorIdleFerramentas;
    public float forcaSlope;
    public float forcaSlopeRayDist;
    public LayerMask roofMask;
    private bool roofTouch;
    [HideInInspector] public bool ligado;
    private bool isJumping;
    [HideInInspector] public bool luzLanternaLigada;
    private bool isCrouching;
    [HideInInspector] public bool correndo;
    private bool levantado = true;
    [HideInInspector] public bool segurandoCam;
    [HideInInspector] public bool segurandoLupa;
    Vector3 movimento = Vector3.zero;
    private Vector3 ferramentaInicialPos;
    private Vector3 camInicialPos;
    private Vector3 balançoAlvoCam;
    private Vector3 balançoAlvoFerramentas;
    [SerializeField] private AudioClip cameraSom;
    [SerializeField] private AudioClip lupaSom;
    [SerializeField] private AudioClip lamparinaSom;
    [SerializeField] private AudioClip apagarLamparinaSom;
    [SerializeField] private AudioClip lamparinaSemOleoSom;
    [SerializeField] private AudioClip puloSom;
    [SerializeField] private AudioClip andarFloresta;
    [SerializeField] private AudioClip andarCaverna;
    [SerializeField] private AudioClip andarIndoor;
    [SerializeField] private AudioClip correrFloresta;
    [SerializeField] private AudioClip correrCaverna;
    [SerializeField] private AudioClip correrIndoor;


    void Start()
    {
        velocidade = velAndar;
        luzLanternaLigada = false;
        ferramentaInicialPos = ferramentas.localPosition;
        camInicialPos = cam.localPosition;
    }

    public void Update()
    {
        //Checa o teto para abaixar
        roofTouch = Physics.CheckSphere(roofCheck.position, roofDist, roofMask);
        if(roofTouch && !isCrouching)
        {
            controlador.height = 1.9f;
            controlador.center = new Vector3(0, -0.85f, 0);
            cam.localPosition = new Vector3(0, 0.4f, 0);
            velocidade = velAbaixar;
            isCrouching = true;
            levantado = false;

        }
        else if(!roofTouch && !levantado)
        {
            controlador.height = 3.8f;
            controlador.center = new Vector3(0, 0, 0);
            cam.localPosition = new Vector3(0, 1.3f, 0);
            velocidade = velAndar;
            isCrouching = false;
            levantado = true;
        }
        
        Agachado();
        Andar();
        Pular();
        Lanterna();
        Correr();
        AndarDevagar();
        Camera();
        Lupa();
        BalançaCamera();
    }

    private void Andar()
    {
        float horizInput = Input.GetAxis("Horizontal");
        float vertInput = Input.GetAxis("Vertical");
        movimento.x = 0;
        movimento.z = 0;
        movimento += horizInput * transform.right * velocidade;
        movimento += vertInput * transform.forward * velocidade;
        //Gravidade
        movimento.y -= gravidade * Time.deltaTime;
        //Controlador de movimento
        controlador.Move(movimento * Time.deltaTime);

        if((vertInput != 0 || horizInput != 0) && OnSlope())
        {
            controlador.Move(Vector3.down * controlador.height / 2 * forcaSlope * Time.deltaTime);
        }
    }

    public bool OnSlope()
    {
        if(isJumping)
            return false;

        RaycastHit hit;
        if(Physics.Raycast(transform.position, Vector3.down, out hit, controlador.height / 2 * forcaSlopeRayDist))
        {
            if(hit.normal != Vector3.up)
                return true;

            if(menu.GetComponent<Menu>().menuActive == false)
            {
                if(hit.collider.CompareTag("Terreno") && somAndar.isPlaying == false && correndo == false){
                    somAndar.Stop();
                    somAndar.PlayOneShot(andarFloresta);
                }
                if(hit.collider.CompareTag("Terreno") && somAndar.isPlaying == false && correndo == true)
                {
                    somAndar.Stop();
                    somAndar.PlayOneShot(correrFloresta);
                }

                if(hit.collider.CompareTag("Caverna") && somAndar.isPlaying == false && correndo == false){
                    somAndar.Stop();
                    somAndar.PlayOneShot(andarCaverna);
                }
                if(hit.collider.CompareTag("Caverna") && somAndar.isPlaying == false && correndo == true)
                {
                    somAndar.Stop();
                    somAndar.PlayOneShot(correrCaverna);
                }
            
                if(hit.collider.CompareTag("Indoor") && somAndar.isPlaying == false && correndo == false){
                    somAndar.Stop();
                    somAndar.PlayOneShot(andarIndoor);
                }
                if(hit.collider.CompareTag("Indoor") && somAndar.isPlaying == false && correndo == true)
                {
                    somAndar.Stop();
                    somAndar.PlayOneShot(correrIndoor);
                }
            }
            else
            {
                somAndar.Stop();
            }
            
        }
        return false;
    }

    private void Pular()
    {
        if(controlador.isGrounded && folego.GetComponent<BarraFolego>().semFolego == false)
        {
            movimento.y = 0;
            if(Input.GetButtonDown("Jump"))
            {
                movimento.y = pulo;
                BarraFolego.instance.UsaFolegoPulo(10);
                isJumping = true;
                audioPlayer.PlayOneShot(puloSom);
            }
            else
            {
                isJumping = false;
            }
        }
    }

    private void Lanterna()
    {
        if(luzLanternaLigada == true){
            luzLanterna.SetActive(true);
        }
        if (luzLanternaLigada == false){
            luzLanterna.SetActive(false);
        }

        if(Input.GetKeyDown(KeyCode.F) && !ligado)
        {
            lamparinaAnim.Play("Pegar Lamparina");
            ligado = true;
        }
        else if(Input.GetKeyDown(KeyCode.F) && ligado)
        {
            lamparinaAnim.Play("Guardar Lamparina");
            ligado = false;
            luzLanternaLigada = false;
        }
        
        if(ligado == true && oilForLampRaycast.GetComponent<OilForLampRaycast>().semOleo == true && Input.GetMouseButtonDown(1))
        {
            luzLanternaLigada = false;
            audioPlayer.PlayOneShot(lamparinaSemOleoSom);
        }
        else if(ligado == true && luzLanternaLigada == false && Input.GetMouseButtonDown(1)){
            luzLanternaLigada = true;
            audioPlayer.PlayOneShot(lamparinaSom);
        }

        else if(ligado == true && luzLanternaLigada == true && Input.GetMouseButtonDown(1)){
            luzLanternaLigada = false;
            audioPlayer.PlayOneShot(apagarLamparinaSom);
        }
    }

    private void Agachado()
    {
        if(Input.GetKey(KeyCode.LeftControl) && controlador.isGrounded)
        {
            velocidade = velAbaixar;
            controlador.height = 1.9f;
            controlador.center = new Vector3(0, -0.85f, 0);
            cam.localPosition = new Vector3(0, 0.4f, 0);
            isCrouching = true;
        }
        else if(Input.GetKeyUp(KeyCode.LeftControl))
        {
            velocidade = velAndar;
            controlador.height = 3.6f;
            controlador.center = new Vector3(0, 0, 0);
            cam.localPosition = new Vector3(0, 1.6f, 0);
            isCrouching = false;
        }
    }

    private void Correr()
    {

        if(folego.GetComponent<BarraFolego>().semFolego == false)
        {
            if(Input.GetKey(KeyCode.LeftShift) && controlador.isGrounded && !isCrouching)
            {
                velocidade = velCorrer;
                BarraFolego.instance.UsaFolegoCorrida(10);
                correndo = true;
            } 
            else if(Input.GetKeyUp(KeyCode.LeftShift) || controlador.isGrounded == false)
            {
                velocidade = velAndar;
                correndo = false;
            }
        }
        else
        {
            if(isCrouching)
            {
                velocidade = velAbaixar;
            }
            else
            {
                velocidade = velAndar;
                correndo = false;
            }
        }
    }

    private void AndarDevagar()
    {
        if(Input.GetKey(KeyCode.LeftAlt) && controlador.isGrounded && !isCrouching)
        {
            velocidade = velCaminhar;
        }
        else if(Input.GetKeyUp(KeyCode.LeftAlt) || controlador.isGrounded == false)
        {
            velocidade = velAndar;
        }
    }

    public void Camera()
    {
        if(!segurandoLupa)
        {
            if(Input.GetKeyDown(KeyCode.C) && !segurandoCam)
            {
                audioPlayer.PlayOneShot(cameraSom);
                cameraAnim.Play("Pegar Camera");
                segurandoCam = true;
            }
            else if(Input.GetKeyDown(KeyCode.C) && segurandoCam)
            {
                audioPlayer.PlayOneShot(cameraSom);
                cameraAnim.Play("Guardar Camera");
                segurandoCam = false;
            }
        }
    }

    public void Lupa()
    {
        if(!segurandoCam)
        {
            if(Input.GetKeyDown(KeyCode.G) && !segurandoLupa)
            {
                audioPlayer.PlayOneShot(lupaSom);
                lupaAnim.Play("Pegar Lupa");
                segurandoLupa = true;
            }
            else if(Input.GetKeyDown(KeyCode.G) && segurandoLupa)
            {
                audioPlayer.PlayOneShot(lupaSom);
                lupaAnim.Play("Guardar Lupa");
                segurandoLupa = false;
            }
        }
    }

    private void BalancaCabecaCam(float pz, float intensidadeX, float intensidadeY)
    {
        balançoAlvoCam = camInicialPos + new Vector3(Mathf.Cos(pz) * intensidadeX, Mathf.Sin(pz * 2) * intensidadeY, 0);
    }

    private void BalancaFerramentas(float pz2, float intensidadeX2, float intensidadeY2)
    {
        balançoAlvoFerramentas = ferramentaInicialPos + new Vector3(Mathf.Cos(pz2) * intensidadeX2, Mathf.Sin(pz2 * 2) * intensidadeY2, 0);
    }

    public void BalançaCamera()
    {
        if(!isCrouching)
        {
            //Balanço da cabeça na camera
            if(movimento.x == 0 && movimento.z == 0)
            {
                BalancaCabecaCam(contadorIdleCam, 0.04f, 0.04f);
                contadorIdleCam += Time.deltaTime * 2;
                cam.localPosition = Vector3.Lerp(cam.localPosition, balançoAlvoCam, Time.deltaTime * 2f);
            }
            else if(correndo == false)
            {
                BalancaCabecaCam(contadorMovimentoCam, 0.3f, 0.3f);
                contadorMovimentoCam += Time.deltaTime * 4f;
                cam.localPosition = Vector3.Lerp(cam.localPosition, balançoAlvoCam, Time.deltaTime * 6f);
            }
            else
            {
                BalancaCabecaCam(contadorMovimentoCam, 0.5f, 0.3f);
                contadorMovimentoCam += Time.deltaTime * 6f;
                cam.localPosition = Vector3.Lerp(cam.localPosition, balançoAlvoCam, Time.deltaTime * 10f);
            }
            //Balanço das ferramentas
            if(movimento.x == 0 && movimento.z == 0) 
            {
                BalancaFerramentas(contadorIdleFerramentas, 0.02f, 0.02f);
                contadorIdleFerramentas += Time.deltaTime;
                ferramentas.localPosition = Vector3.Lerp(ferramentas.localPosition, balançoAlvoFerramentas, Time.deltaTime * 2f);
            }
            else if(!correndo)
            {
                BalancaFerramentas(contadorMovimentoFerramentas, 0.035f, 0.035f);
                contadorMovimentoFerramentas += Time.deltaTime * 3f;
                ferramentas.localPosition = Vector3.Lerp(ferramentas.localPosition, balançoAlvoFerramentas, Time.deltaTime * 6f);
            }
            else
            {
                BalancaFerramentas(contadorMovimentoFerramentas, 0.1f, 0.075f);
                contadorMovimentoFerramentas += Time.deltaTime * 6f;
                ferramentas.localPosition = Vector3.Lerp(ferramentas.localPosition, balançoAlvoFerramentas, Time.deltaTime * 10f);
            }
        }
    }
}