using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsGoUp : MonoBehaviour
{
    [SerializeField] private RectTransform credits;
    [SerializeField] private Vector2 startPosition;
    [SerializeField] private float speed;
    [SerializeField] private int maxHeight;

    void Start(){
        startPosition = new Vector2 (Screen.width / 2, (Screen.height /2) - Screen.height);
        Cursor.lockState = CursorLockMode.None;
    }

    void Update()
    {
        credits.transform.Translate(0, 1 * Time.deltaTime * speed, 0);

        if(credits.transform.position.y > maxHeight){
            credits.transform.position = startPosition;
        }
    }
}