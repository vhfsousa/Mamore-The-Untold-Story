using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarregaFoto : MonoBehaviour
{
    public GameObject imagem;
    private Sprite last_screenshot_save;
    public string localSalvo;
    int resWidth = 1920;
    int resHeight = 1080;
 
    private void Start()
    {
        string path = Application.dataPath + localSalvo;
        last_screenshot_save = LoadSprite(path);
        imagem.GetComponent<Image>().sprite = last_screenshot_save;
    }
    private void Update()
    {
        if(imagem.GetComponent<Image>().sprite == null)
        {
            imagem.SetActive(false);
        }
        if(imagem.GetComponent<Image>().sprite != null)
        {
            imagem.SetActive(true);
        }
    }
 
    private Sprite LoadSprite(string path)
    {
        if (string.IsNullOrEmpty(path)) return null;
        if (System.IO.File.Exists(path))
        {
            byte[] bytes = System.IO.File.ReadAllBytes(path);
            Texture2D texture = new Texture2D(1, 1);
            texture.LoadImage(bytes);
            Sprite sprite = Sprite.Create(texture, new Rect(0, 0, resWidth, resHeight), new Vector2(0.5f, 0.5f));
            return sprite;
        }
        return null;
    }
}
