using UnityEngine;
using System.Collections.Generic;

public class RoomManager : MonoBehaviour
{
    public GameManager gameManager;
    public List<Transform> rooms = new List<Transform>();
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


    // Use this for initialization
    void Start()
    {
        playerTempColour = player.renderer.material.color;

        roomsTempColour = rooms[0].GetChild(0).renderer.material.color;

        wallsTempColour = walls[0].renderer.material.color;

        floorsTempColour = floors[0].renderer.material.color;

   
    }

    // Update is called once per frame
    void Update()
    {

        if (!gameManager.levelManager.worldState)
        {

            player.renderer.material.color = Color.Lerp(
                       player.renderer.material.color, playerColour, Time.deltaTime);

            foreach (Transform o in rooms)
            {
                foreach (Transform t in o)
                {
                        t.renderer.material.color = Color.Lerp(
                           t.renderer.material.color, obstacleColours, Time.deltaTime);
                }
            }

            foreach (Transform t in walls)
            {
                if (t.gameObject.activeSelf == true)
                {
                    t.renderer.material.color = Color.Lerp(
                           t.renderer.material.color, wallColour, Time.deltaTime);
                }
            }

            foreach (Transform t in floors)
            {
                t.renderer.material.color = Color.Lerp(
                       t.renderer.material.color, floorColour, Time.deltaTime);
            }
        }

        else
        {
            player.renderer.material.color = Color.Lerp(
                      player.renderer.material.color, playerTempColour, Time.deltaTime * 5);

            foreach (Transform o in rooms)
            {
                foreach (Transform t in o)
                {
                        t.renderer.material.color = Color.Lerp(
                          t.renderer.material.color, roomsTempColour, Time.deltaTime * 5);
                }
            }

            foreach (Transform t in walls)
            {
                t.renderer.material.color = Color.Lerp(
                      t.renderer.material.color, wallsTempColour, Time.deltaTime * 5);
            }

            foreach (Transform t in floors)
            {
                t.renderer.material.color = Color.Lerp(
                       t.renderer.material.color, floorsTempColour, Time.deltaTime * 5);
            }
        }
    }
}
