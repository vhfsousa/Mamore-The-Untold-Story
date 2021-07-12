using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ObjectController : MonoBehaviour
{
    [SerializeField] private GameObject dicaNova;
    [SerializeField] private InspectController InspectController;

    public void ShowImage()
    {
        InspectController.ShowObjectImage(dicaNova);
    }
    public void HideImage()
    {
        InspectController.HideObjectImage(dicaNova);
    }
}