using UnityEngine;
using System.Collections;

public class ButtonPlay : MonoBehaviour
{
    public GameManager gameManager;

    void OnMouseUp()
    {
        gameManager.buttonManager.Play();
    }

}
