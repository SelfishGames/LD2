using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TipScript : MonoBehaviour
{
    public GameManager gameManager;
    public Transform player;

    public List<TextMesh> tipList;

    public bool tipActive;

    void Start()
    {
        tipActive = false;

        tipList[0].text = "WASD/Arrow Keys\nmove the player";
        tipList[1].text = "Left Control changes world\nand Space bar to jump";
        tipList[3].text = "Hey, is that Blinky?";
    }

    void Update()
    {
        //Sets the tip for the current level to active and all others inactive
        for (int i = 0; i < tipList.Count; i++)
            if (i != gameManager.levelManager.currentLevel)
                tipList[i].gameObject.SetActive(false);

        Debug.Log(gameManager.levelManager.currentLevel);
        switch(gameManager.levelManager.currentLevel)
        {
            case 0:
                {
                    if(!tipActive)
                        if (player.position.x <= 0f)
                        {
                            tipList[0].gameObject.SetActive(true);
                            tipActive = true;
                        }
                    break;
                }
            case 1:
                {   
                    if (!tipActive)
                        if (player.position.x >= -3f)
                        {
                            tipList[1].gameObject.SetActive(true);
                            tipActive = true;
                        }
                    break;
                }
            case 3:
                {
                    if (!tipActive)
                        if (player.position.x >= -3f && !gameManager.levelLoading)
                        {
                            tipList[3].gameObject.SetActive(true);
                            tipActive = true;
                        } 
                    break;
                }
            default:
                {
                    break;
                }
        }
    }
}
