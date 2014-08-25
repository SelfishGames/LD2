using UnityEngine;
using System.Collections;

public class Fade : MonoBehaviour
{
    public float fadeSpeed;
    public float alphaCheck;


    void Awake()
    {
        guiTexture.pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
    }

    void Update()
    {
        alphaCheck = guiTexture.color.a;
    }

    public void FadeClear()
    {
        guiTexture.color = Color.Lerp(guiTexture.color, Color.clear, fadeSpeed * Time.deltaTime);
    }

    public void FadeToBlack()
    {

        guiTexture.color = Color.Lerp(guiTexture.color, Color.black, fadeSpeed * Time.deltaTime);
    }
}
