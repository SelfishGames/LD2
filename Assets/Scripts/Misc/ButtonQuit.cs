using UnityEngine;
using System.Collections;

public class ButtonQuit : MonoBehaviour
{
    public GameManager gameManager;

    void OnMouseUp()
    {
        gameManager.buttonManager.Quit();
    }
}
