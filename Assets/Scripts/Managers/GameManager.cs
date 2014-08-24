using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    // General public objects 
    // (0,1 are player explosions, 2,3 are end particle systems)
    public GameObject[] particleSystems;
    public Transform player;

    // Scripts
    public CameraManager cameraManager;
    public LevelManager levelManager;
    public PlayerManager playerManager;
    public SoundManager soundManager;

    void Start()
    {
    }

    void Update()
    {
        if (cameraManager.transform.GetChild(0).gameObject.activeSelf && Input.GetKeyDown("space"))
        {
            cameraManager.transform.GetChild(0).gameObject.SetActive(false);
            player.gameObject.SetActive(true);
        }

        if (Input.GetKey(KeyCode.Escape))
            Application.Quit();
    }

    public void TriggerCollision()
    {
        if(!levelManager.worldState)
        {
            // Set the location of the explosion.
            particleSystems[0].transform.localPosition = player.transform.localPosition;
            // Play the explosion.
            particleSystems[0].SetActive(true);
        }

        if (levelManager.worldState)
        {
            // Set the location of the explosion.
            particleSystems[1].transform.localPosition = player.transform.localPosition;
            // Play the explosion.
            particleSystems[1].SetActive(true);
        }
       
        
        //Play death sound
        soundManager.PlayExplosionSound();
    }
}
