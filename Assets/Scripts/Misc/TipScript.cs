using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TipScript : MonoBehaviour
{
    public GameManager gameManager;

    public TextMesh level0Tip,
        level1Tip,
        level3Tip;

    public List<TextMesh> tipList;

    // Use this for initialization
    void Start()
    {
        tipList[0].text = "WASD/Arrow Keys move the player";
        tipList[1].text = "Left Control changes world\nand Space bar to jump";
        tipList[3].text = "Hey, is that Blinky?";
    }

    // Update is called once per frame
    void Update()
    {
        //Sets the tip for the current level to active and all others inactive
        for (int i = 0; i < tipList.Count; i++)
            if (i != gameManager.levelManager.currentLevel)
                tipList[i].gameObject.SetActive(false);
            else
                tipList[i].gameObject.SetActive(true);
    }
}
