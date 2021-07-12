using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClueController : MonoBehaviour
{
    [SerializeField] private GameController gameController;
    [SerializeField] public bool[] pontuou;

    void Start(){
        pontuou = new bool [8];
    }
    

    public void PontuouFoto0(){
        pontuou[0] = true;
        if(pontuou[0] == true){
            gameController.AumentaPonto();
            pontuou[0] = false;
        }
    }

    public void PontuouFoto1(){
        pontuou[1] = true;
        if(pontuou[1] == true){
            gameController.AumentaPonto();
            pontuou[1] = false;
        }
    }

    public void PontuouFoto2(){
        pontuou[2] = true;
        if(pontuou[2] == true){
            gameController.AumentaPonto();
            pontuou[2] = false;
        }
    }

    public void PontuouFoto3(){
        pontuou[3] = true;
        if(pontuou[3] == true){
            gameController.AumentaPonto();
            pontuou[3] = false;
        }
    }

    public void PontuouFoto4(){
        pontuou[4] = true;
        if(pontuou[4] == true){
            gameController.AumentaPonto();
            pontuou[4] = false;
        }
    }

    public void PontuouFoto5(){
        pontuou[5] = true;
        if(pontuou[5] == true){
            gameController.AumentaPonto();
            pontuou[5] = false;
        }
    }

    public void PontuouFoto6(){
        pontuou[6] = true;
        if(pontuou[6] == true){
            gameController.AumentaPonto();
            pontuou[6] = false;
        }
    }

    public void PontuouFoto7(){
        pontuou[7] = true;
        if(pontuou[7] == true){
            gameController.AumentaPonto();
            pontuou[7] = false;
        }
    }
}