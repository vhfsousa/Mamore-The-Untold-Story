using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraFolego : MonoBehaviour
{
    [SerializeField] private Slider folego;
    private CanvasGroup canvGroup;
    private float folegoMax = 100;
    private float folegoAtual;
    public float duracaoFade = 0.4f;
    private WaitForSeconds regenTick = new WaitForSeconds(0.1f);
    private Coroutine regen;
    public static BarraFolego instance;
    public bool semFolego;
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        folegoAtual = folegoMax;
        folego.maxValue = folegoMax;
        folego.value = folegoMax;
        canvGroup = GetComponent<CanvasGroup>();
    }

    void Update()
    {
        if(folegoAtual >= 30)
        {
            semFolego = false;
        }
        Fade();
    }

    public void UsaFolegoPulo(float quantidade)
    {
        if(folegoAtual - quantidade >= 0)
        {
            folegoAtual -= quantidade;
            folego.value = folegoAtual;
            if(regen != null) StopCoroutine(regen);
            regen = StartCoroutine(FolegoRegen());
        }
        else
        {
            semFolego = true;
        }
    }
    public void UsaFolegoCorrida(float quantidade)
    {
        if(folegoAtual - quantidade >= 0)
        {
            folegoAtual -= quantidade * Time.deltaTime;
            folego.value = folegoAtual;
            if(regen != null) StopCoroutine(regen);
            regen = StartCoroutine(FolegoRegen());
        }
        else
        {
            semFolego = true;
        }
    }
    public void Fade()
    {
        if(folego.value == 100)
        {
            StartCoroutine(FazerFade());
        }
        if(folegoAtual < 100)
        {
            canvGroup.alpha = 1;
        }
    }

    private IEnumerator FolegoRegen()
    {
        yield return new WaitForSeconds(2);

        while(folegoAtual < folegoMax)
        {
            folegoAtual += folegoMax / 80;
            folego.value = folegoAtual;
            yield return regenTick;
        }
        regen = null;
    }

    public IEnumerator FazerFade()
    {
        float contador = 0f;

        while(contador < duracaoFade)
        {
            contador += Time.deltaTime;
            canvGroup.alpha -= Time.deltaTime * duracaoFade;

            yield return null;
        }
    }
}