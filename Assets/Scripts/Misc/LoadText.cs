using UnityEngine;
using System.Collections;

public class LoadText : MonoBehaviour
{
    public GameManager gameManager;
    public TextMesh loadText;

    // Use this for initialization
    void Start ()
    {

    }

    // Update is called once per frame
    void Update ()
    {
         loadText.text = ("Congratulations, Level " +  gameManager.levelManager.currentLevel + " Complete." +
            "\nPress Space to continue to the next level.");
    }
}
