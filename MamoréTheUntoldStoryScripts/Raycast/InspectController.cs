using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class InspectController : MonoBehaviour
{
    [SerializeField] private GameObject dica;

    public void ShowObjectImage(GameObject dicaNova)
    {
        dica = dicaNova;
        dica.SetActive(true);
    }
    public void HideObjectImage(GameObject dicaNova)
    {
        dica.SetActive(false);
    }
}