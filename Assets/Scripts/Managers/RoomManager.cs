using UnityEngine;
using System.Collections.Generic;

public class RoomManager : MonoBehaviour
{
    #region Fields
    public GameManager gameManager;
    public List<Transform> obstacles = new List<Transform>();
    public List<Transform> walls = new List<Transform>();
    public List<Transform> floors = new List<Transform>();
    public Transform player;

    public Color playerColour;
    public Color obstacleColours;
    public Color wallColour;
    public Color floorColour;

    private Color roomsTempColour;
    private Color wallsTempColour;
    private Color floorsTempColour;
    private Color playerTempColour;
    #endregion

    #region Start
    void Start()
    {
        //Saves the objects initial colours to lerp from and to
        playerTempColour = player.renderer.material.color;
        roomsTempColour = obstacles[0].GetChild(0).renderer.material.color;
        wallsTempColour = walls[0].renderer.material.color;
        floorsTempColour = floors[0].renderer.material.color;
    }
    #endregion

    #region Update
    void Update()
    {
        //Changes the colour of all objects in the scene based on the worldState
        if (!gameManager.levelManager.worldState)
        {
            //Player to colour
            player.renderer.material.color = Color.Lerp(
                       player.renderer.material.color, playerColour, Time.deltaTime);

            //Obstacles to colour
            foreach (Transform o in obstacles[gameManager.levelManager.currentLevel].transform)
            {
                o.renderer.material.color = Color.Lerp(
                    o.renderer.material.color, obstacleColours, Time.deltaTime);
            }

            //Walls to colour
            foreach (Transform t in walls)
            {
                t.renderer.material.color = Color.Lerp(
                       t.renderer.material.color, wallColour, Time.deltaTime);
            }

            //Floors to colour
            foreach (Transform t in floors)
            {
                t.renderer.material.color = Color.Lerp(
                       t.renderer.material.color, floorColour, Time.deltaTime);
            }
        }
        else
        {
            //Player to clear
            player.renderer.material.color = Color.Lerp(
                      player.renderer.material.color, playerTempColour, Time.deltaTime * 5);

            //Obstacles to clear
            foreach (Transform o in obstacles[gameManager.levelManager.currentLevel].transform)
            {
                o.renderer.material.color = Color.Lerp(
                    o.renderer.material.color, roomsTempColour, Time.deltaTime * 5);
            }

            //Walls to clear
            foreach (Transform t in walls)
            {
                t.renderer.material.color = Color.Lerp(
                      t.renderer.material.color, wallsTempColour, Time.deltaTime * 5);
            }

            //Floors to clear
            foreach (Transform t in floors)
            {
                t.renderer.material.color = Color.Lerp(
                       t.renderer.material.color, floorsTempColour, Time.deltaTime * 5);
            }
        }
    }
    #endregion
}
