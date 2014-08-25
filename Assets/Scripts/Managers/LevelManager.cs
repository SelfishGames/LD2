using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour
{
    #region Fields
    public GameManager gameManager;

    public Transform player;
    public Transform nearWall;
    public Transform ceiling;

    public Light mainLight;

    //True is day, false is night
    [HideInInspector]
    public bool worldState = true;
    [HideInInspector]
    public int currentLevel = 0;
    public List<GameObject> levels = new List<GameObject>();

    private Color tempWallColour,
        tempCeilingColour;
    #endregion

    #region Start
    void Start()
    {
        // Run ArrangeObstacles so that I do not keep forgetting to re acrivate the 
        // first obstacle.
        ArrangeObstacles();
        tempWallColour = nearWall.renderer.material.color;
        tempCeilingColour = ceiling.renderer.material.color;
    }
    #endregion

    #region Update
    void Update()
    {

        if(gameManager.cameraManager.gameObject.activeSelf == true)
        {
            //Changes worldStates 
            if (Input.GetKeyDown(KeyCode.LeftShift))
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

        }


        switch (worldState)
        {
            //Top
            case true:
                {
                    //Fades the nearWall and ceiling in and out
                    nearWall.renderer.material.color = Color.Lerp(
                        nearWall.renderer.material.color, tempWallColour, Time.deltaTime * 1.5f);

                    ceiling.renderer.material.color = Color.Lerp(
                        ceiling.renderer.material.color, Color.clear, Time.deltaTime * 1.5f);

                    gameManager.playerManager.particleSystems[0].SetActive(false);
                    gameManager.playerManager.particleSystems[1].SetActive(true);
                    gameManager.particleSystems[3].SetActive(false);
                    gameManager.particleSystems[2].SetActive(true);


                    return;
                }
            //Side
            case false:
                {
                    //Fades the nearWall and ceiling in and out
                    nearWall.renderer.material.color = Color.Lerp(
                        nearWall.renderer.material.color, Color.clear, Time.deltaTime * 1.5f);

                    ceiling.renderer.material.color = Color.Lerp(
                        ceiling.renderer.material.color, tempCeilingColour, Time.deltaTime * 1.5f);

                    gameManager.playerManager.particleSystems[1].SetActive(false);
                    gameManager.playerManager.particleSystems[0].SetActive(true);
                    gameManager.particleSystems[2].SetActive(false);
                    gameManager.particleSystems[3].SetActive(true);
                    return;
                }
        }
    }
    #endregion

    #region ArrangeObstacles
    public void ArrangeObstacles()
    {
        foreach (GameObject go in levels)
        {
            go.SetActive(false);
            levels[currentLevel].SetActive(true);
        }
    }
    #endregion
}

