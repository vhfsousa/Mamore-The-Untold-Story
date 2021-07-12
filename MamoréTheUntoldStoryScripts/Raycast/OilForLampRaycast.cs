using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OilForLampRaycast : MonoBehaviour
{
    private AudioSource audioOil;
    public float lampFuel;
    public float duracaoFade = 0.4f;
    [SerializeField] OilForLamp oleoSelecionado;
    [SerializeField] private LayerMask oilLayerMask;
    [SerializeField] private GameObject lamparina;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject keroseneSymbol;
    [SerializeField] private AudioClip oleoSom;
    public bool semOleo;
    [SerializeField] private Slider oleoSlider;
    private CanvasGroup canvGroup;

    void Start()
    {
        oleoSlider.maxValue = lampFuel;
        lampFuel = 100;
        audioOil = GetComponent<AudioSource>();
        canvGroup = oleoSlider.GetComponent<CanvasGroup>();
    }

    void Update()
    {
        Fade();
        oleoSlider.value = lampFuel;

        //Não deixar passar de 100 o máximo de óleo para lanterna
        if(lampFuel >= 100)
        {
            lampFuel = 100;
        }

        //Não deixar ficar menor que 0 o mínimo da lanterna e apagar a lanterna caso esgote o óleo
        if(lampFuel <= 0){
            //Fazer um barulho para apagar e parar a animação;
            lampFuel = 0;
            player.GetComponent<Player>().luzLanternaLigada = false;
            semOleo = true;
        }

        //Criar o Raycast
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        OilForLamp embalagemLampada = null;

        //Detectar se colidiu com a lata de óleo e atrelá-la, senão deixar sem nenhuma para o player
        if(Physics.Raycast(transform.position, fwd, out hit, 4, oilLayerMask.value))
        {
            if(hit.collider.CompareTag("Oleo"))
            {
                keroseneSymbol.SetActive(true);
                oleoSelecionado = hit.transform.GetComponent<OilForLamp>();
            }
        }
        else
        {
            keroseneSymbol.SetActive(false);
            oleoSelecionado = null;
        }

        //Recarregar o oleo da lâmpada e tira o objeto atrelado
        if(oleoSelecionado == true && Input.GetKeyDown(KeyCode.E)){
            embalagemLampada = oleoSelecionado;
            embalagemLampada.RecarregarLampada();
            oleoSelecionado = null;
            audioOil.PlayOneShot(oleoSom);
        }        

        //Faz com que a lanterna seja gasta
        if(lamparina.GetComponent<Player>().luzLanternaLigada == true){
            //Descer aqui o nível da lanterna por tempo
            lampFuel -=  1 * Time.deltaTime;
        }
    }


    void Fade()
    {
        if(player.GetComponent<Player>().luzLanternaLigada == false)
        {
            StartCoroutine(FazerFade());
        }
        if(player.GetComponent<Player>().luzLanternaLigada == true)
        {
            canvGroup.alpha = 1;
        }
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