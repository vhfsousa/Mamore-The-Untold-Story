using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.IO;

public class OptionsWindow : MonoBehaviour
{
    private float mouseSensibility;
    private float volumeGeral;
    [SerializeField] private Text volumeText;
    [SerializeField] private Text sensibilityText;
    [SerializeField] private AudioMixer mixerGeral;

    void Start()
    {
        volumeGeral = PlayerPrefs.GetFloat("Volume");
        mouseSensibility = PlayerPrefs.GetFloat("Sensibilidade");
    }

    void Update()
    {
        volumeText.text = (Mathf.RoundToInt(volumeGeral * 100)).ToString();
        sensibilityText.text = (mouseSensibility/1000).ToString();
    }

    public void AjustarVolume(float receivedVolume){
        volumeGeral = receivedVolume;
        PlayerPrefs.SetFloat("Volume", volumeGeral);
        mixerGeral.SetFloat("MasterVolume", Mathf.Log10(volumeGeral) * 20);
    }

    public void AjustarSensibilidade(float mSpeed){
        mouseSensibility = mSpeed * 1000;
        PlayerPrefs.SetFloat("Sensibilidade", mouseSensibility);
    }

    public void VSync(bool value){
        if(value == true){
            QualitySettings.vSyncCount = 2;
        }else if(value == false){
            QualitySettings.vSyncCount = 0;
        }
    }
}