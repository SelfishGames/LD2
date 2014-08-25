using UnityEngine;
using System.Collections;

public class ButtonPlay : MonoBehaviour
{
    public GameManager gameManager;

    public Texture pressedTexture;
    public Texture defaultTexture;

    #region OnMouseDown
    void OnMouseDown()
    {
        guiTexture.texture = pressedTexture;
    }
    #endregion

    #region OnMouseUp
    void OnMouseUp()
    {
        StartCoroutine("CallPlay");
    }
    #endregion

    IEnumerator CallPlay()
    {
        yield return new WaitForSeconds(.2f);
        guiTexture.texture = defaultTexture;
        gameManager.buttonManager.Play();
    }
}
