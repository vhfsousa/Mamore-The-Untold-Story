using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    private AudioSource audioCamera;
    [SerializeField] private Camera cameraFotografica;
    public float mouseSense;
    private float xRotation = 0f;
    [SerializeField] private Transform player;
    public int zoom = 20;
    public int normal = 80;
    public float smooth = 5f;
    private bool isZoomed = false;
    public AudioClip ZoomSom;
    

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        mouseSense = PlayerPrefs.GetFloat("Sensibilidade");
        audioCamera = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSense * 0.1f * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSense * 0.1f * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        player.Rotate(Vector3.up * mouseX);

        Zoom();
    }

    private void Zoom()
    {
        if(Input.GetKeyDown(KeyCode.Z) && player.gameObject.GetComponent<Player>().segurandoCam == true)
        {
            isZoomed = !isZoomed;
            audioCamera.PlayOneShot(ZoomSom);
        }
        else if(player.gameObject.GetComponent<Player>().segurandoCam == false)
        {
            isZoomed = false;
        }

        if(isZoomed)
        {
            GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, zoom, Time.deltaTime / 2 * smooth);
            cameraFotografica.fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, zoom, Time.deltaTime / 2 * smooth);
        }
        else
        {
            GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, normal, Time.deltaTime / 2 * smooth);
            cameraFotografica.fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, normal, Time.deltaTime / 2 * smooth);
        }
    }
}