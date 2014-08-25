using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour
{
    #region Fields
    public GameManager gameManager;

    public AudioSource explosion;
    public AudioSource jump;
    public AudioSource collection;
    public AudioSource endLevel;
    public AudioSource achievement;

    public AudioSource gameAmbient;
    public AudioSource demoIdea;
    #endregion

    #region Start
    void Start()
    {
        gameAmbient.Play();
        demoIdea.Play();
    }
    #endregion

    #region Update
    void Update()
    {
        gameAmbient.volume = 0.1f;
        demoIdea.volume = 0.1f;
        
        //Fade songs based on the worldState 
        if (gameManager.levelManager.worldState)
        {
            FadeIn(gameAmbient);
            FadeOut(demoIdea);
        }
        else
        {
            FadeIn(demoIdea);
            FadeOut(gameAmbient);
        }
    }
    #endregion

    #region VolumeFades
    void FadeIn(AudioSource sound)
    {
        sound.volume = Mathf.Lerp(sound.volume, 1f, Time.deltaTime);
    }

    void FadeOut(AudioSource sound)
    {
        sound.volume = Mathf.Lerp(sound.volume, 0f, Time.deltaTime);
    }
    #endregion
}
