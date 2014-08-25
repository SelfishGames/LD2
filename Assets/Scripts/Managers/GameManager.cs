using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    // General public objects 
    // (0,1 are player explosions, 2,3 are end particle systems)
    public GameObject[] particleSystems;
    public Transform player;
    //[HideInInspector]
    public bool levelLoading = false;
    public bool unfade = false;
    public EndPlayer endplayer;

    public GameObject mainCam;
    public GameObject loadCamera;
    // Scripts
    public CameraManager cameraManager;
    public LevelManager levelManager;
    public PlayerManager playerManager;
    public SoundManager soundManager;
    public ButtonManager buttonManager;
    public BonusManager bonusManager;

    public Fade fade;

    public bool fadeBlack;
    public bool fadeClear;

    public int currentState;

    void Start()
    {
        currentState = -1;
        fadeBlack = false;
        fadeClear = true;
        if(Application.loadedLevelName == "Main")
        {
            mainCam.SetActive(true);
            loadCamera.SetActive(false);
        }
    }

    void Update()
    {
        if(Application.loadedLevelName == "Main")
        {
            if (fadeClear == true)
            {
                fade.FadeClear();

            }

            if (fadeBlack == true)
            {
                fade.FadeToBlack();

                if (fade.alphaCheck >= 0.5f)
                {
                    fadeBlack = false;
                }
            }
        }
        

        switch(currentState)
        {
            case 0:
                {
                    fadeBlack = true;
                   
                    if (fade.alphaCheck >= 0.5f)
                    {
                        fadeBlack = false;
                        currentState = 1;
                    }

                    break;
                }
            case 1:
                {
                    cameraManager.ResetPosition();
                    mainCam.SetActive(false);
                    loadCamera.SetActive(true);

                    if (Application.loadedLevel == 1)
                    {
                        if (levelLoading == true && Input.GetKeyDown("space"))
                        {
                            //cameraManager.transform.GetChild(0).gameObject.SetActive(false);
                            player.gameObject.SetActive(true);
                            levelLoading = false;
                            endplayer.jumping = false;
                            currentState = 2;
                        }
                    }

                    break;
                }
            case 2:
                {
                    fadeBlack = true;

                    if (fade.alphaCheck >= 0.5f)
                    {
                        fadeBlack = false;
                        currentState = -1;

                        mainCam.SetActive(true);
                        loadCamera.SetActive(false);
                    }

                    break;
                }
            default:
                {
                    break;
                }
        }

        if (Input.GetKey(KeyCode.Escape))
            Application.Quit();
    }

    public void TriggerCollision()
    {
        if(!levelManager.worldState)
        {
            // Set the location of the explosion.
            particleSystems[1].transform.localPosition = player.transform.localPosition;
            // Play the explosion.
            particleSystems[1].SetActive(true);
        }

        if (levelManager.worldState)
        {
            // Set the location of the explosion.
            particleSystems[0].transform.localPosition = player.transform.localPosition;
            // Play the explosion.
            particleSystems[0].SetActive(true);
        }
       
        //Play death sound
        soundManager.PlayExplosionSound();
    }
}
