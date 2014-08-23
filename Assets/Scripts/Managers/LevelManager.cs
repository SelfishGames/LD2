using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour
{
    public GameManager gameManager;

    public Transform player;
    public Transform nearWall;

    //True is day, false is night
    [HideInInspector]
    public bool worldState = true;
    [HideInInspector]
    public int currentLevel = 0;
    public List<GameObject> levels = new List<GameObject>();

    private Color tempWallColour;

    void Start()
    {
        tempWallColour = nearWall.renderer.material.color;
    }

    #region Update
    void Update()
    {
        //Changes worldStates 
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (worldState)
            {
                gameManager.cameraManager.StartLerp(1);
                worldState = false;
            }
            else
            {
                gameManager.cameraManager.StartLerp(2);
                worldState = true;
            }
        }

        switch (worldState)
        {
            //Day
            case true:
                {
                    nearWall.renderer.material.color = Color.Lerp(
                    nearWall.renderer.material.color, tempWallColour, Time.deltaTime);

                    return;
                }
            //Night
            case false:
                {
                    nearWall.renderer.material.color = Color.Lerp(
                    nearWall.renderer.material.color, Color.clear, Time.deltaTime);

                    return;
                }
        }
    }
    #endregion

    public void ArrangeObstacles()
    {
        foreach (GameObject go in levels)
        {
            go.SetActive(false);
            levels[currentLevel].SetActive(true);

        }
    }
}

