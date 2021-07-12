using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InspectRaycast : MonoBehaviour
{
    private AudioSource audioInteract;
    [SerializeField] private LayerMask layerMaskInteract;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject menu;
    private ObjectController raycastedObj;
    private DoorController doorController;
    [SerializeField] private int raycastDist;
    [SerializeField] private GameObject chaveCobre;
    [SerializeField] private GameObject chavePrata;
    [SerializeField] private GameObject chaveDesgastada;
    [SerializeField] private Image chaveCrosshair;
    [SerializeField] private Image cadeadoCrosshair;
    [SerializeField] private Image portaCrosshair;
    [SerializeField] private Image lupaCrosshair;
    private bool isCrosshairActive;
    private bool doOnce;
    private bool dicaAberto;
    public bool inspectedObjectActive;
    [SerializeField] private AudioClip portaSom;
    [SerializeField] private AudioClip destrancaPortaSom;
    [SerializeField] private AudioClip ChaveSom;
    [SerializeField] private AudioClip portaTrancada;

    void Start(){
        inspectedObjectActive = false;
        chaveCobre.SetActive(false);
        chavePrata.SetActive(false);
        audioInteract = GetComponent<AudioSource>();
        chaveCrosshair.gameObject.SetActive(false);
        lupaCrosshair.gameObject.SetActive(false);
        portaCrosshair.gameObject.SetActive(false);
        cadeadoCrosshair.gameObject.SetActive(false);
    }

    void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if(Physics.Raycast(transform.position, fwd, out hit, raycastDist, layerMaskInteract.value))
        {
            if(hit.collider.CompareTag("InteractObj"))
            {
                if(!doOnce)
                {
                    raycastedObj = hit.collider.gameObject.GetComponent<ObjectController>();
                    CrosshairChange(true);
                }
                isCrosshairActive = true;
                doOnce = true;
                if(menu.GetComponent<Menu>().menuActive == false)
                {
                    if(player.GetComponent<Player>().segurandoLupa == true && Input.GetKeyDown(KeyCode.E) && !dicaAberto)
                    {
                        inspectedObjectActive = true;
                        raycastedObj.ShowImage();
                        dicaAberto = true;
                    }
                    else if(Input.GetKeyDown(KeyCode.E) && dicaAberto)
                    {
                        inspectedObjectActive = false;
                        raycastedObj.HideImage();
                        dicaAberto = false;
                    }
                }
            }
            else if(hit.collider.CompareTag("Porta"))
            {
                if(!doOnce)
                {
                    doorController = hit.collider.GetComponentInParent<DoorController>();
                    if(GameController.chaves[doorController.index] == true)
                    {
                        CrosshairChangeDoor(true);
                    }
                    else if(GameController.chaves[doorController.index] == false)
                    {
                        CrosshairChangeLock(true);
                    }
                }
                isCrosshairActive = true;
                doOnce = true;
                if(doorController == null) return;
                if(menu.GetComponent<Menu>().menuActive == false)
                {
                    if(Input.GetKeyDown(KeyCode.E))
                    {
                        if(GameController.chaves[doorController.index] == true)
                        {
                            if(doorController.index == 0){
                                chaveCobre.SetActive(false);
                                audioInteract.PlayOneShot(destrancaPortaSom);
                            }
                            if(doorController.index == 1){
                                chavePrata.SetActive(false);
                                audioInteract.PlayOneShot(destrancaPortaSom);
                            }
                            doorController.PlayAnimation();
                            audioInteract.PlayOneShot(portaSom);
                        }
                        else if(GameController.chaves[doorController.index] == false)
                        {
                            audioInteract.PlayOneShot(portaTrancada);
                        }
                    }
                }
            }
            else if(hit.collider.CompareTag("Chave"))
            {
                if(!doOnce)
                {
                    CrosshairChangeKey(true);
                }
                isCrosshairActive = true;
                doOnce = true;
                if(menu.GetComponent<Menu>().menuActive == false)
                {
                    if(Input.GetKeyDown(KeyCode.E))
                    {
                        GameController.chaves[hit.collider.GetComponent<Chave>().index] = true;
                        if(GameController.chaves[hit.collider.GetComponent<Chave>().index = 0]){
                            PlayerPrefs.SetFloat("Chave1", 1);
                            chaveCobre.SetActive(true);
                            audioInteract.PlayOneShot(ChaveSom);
                        }
                        else if(GameController.chaves[hit.collider.GetComponent<Chave>().index = 1]){
                            PlayerPrefs.SetFloat("Chave2", 1);
                            chavePrata.SetActive(true);
                            audioInteract.PlayOneShot(ChaveSom);
                        }
                        hit.collider.gameObject.SetActive(false);
                    }
                }
            }
        }
        else
        {
            if(isCrosshairActive)
            {
                CrosshairChange(false);
                CrosshairChangeDoor(false);
                CrosshairChangeKey(false);
                CrosshairChangeLock(false);
                doOnce = false;
            }
            if(menu.GetComponent<Menu>().menuActive == false && Input.GetKeyDown(KeyCode.E) && dicaAberto)
            {
                inspectedObjectActive = false;
                raycastedObj.HideImage();
                dicaAberto = false;
            }
        }
    }

    void CrosshairChange(bool on)
    {
        if(on && !doOnce)
        {
            lupaCrosshair.gameObject.SetActive(true);
        }
        else
        {
            lupaCrosshair.gameObject.SetActive(false);
            isCrosshairActive = false;
        }
    }
    void CrosshairChangeDoor(bool on)
    {
        if(on && !doOnce)
        {
            portaCrosshair.gameObject.SetActive(true);
        }
        else
        {
            portaCrosshair.gameObject.SetActive(false);
            isCrosshairActive = false;
        }
    }
    void CrosshairChangeKey(bool on)
    {
        if(on && !doOnce)
        {
            chaveCrosshair.gameObject.SetActive(true);
        }
        else
        {
            chaveCrosshair.gameObject.SetActive(false);
            isCrosshairActive = false;
        }
    }
    void CrosshairChangeLock(bool on)
    {
        if(on && !doOnce)
        {
            cadeadoCrosshair.gameObject.SetActive(true);
        }
        else
        {
            cadeadoCrosshair.gameObject.SetActive(false);
            isCrosshairActive = false;
        }
    }
}