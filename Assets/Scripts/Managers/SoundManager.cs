using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour
{
    #region Fields
    public GameManager gameManager;

    public List<AudioSource> soundFX;
    public List<AudioSource> music;
    #endregion

    #region Start
    void Start()
    {
        music[0].Play();
        music[1].Play();
    }
    #endregion

    #region Update
    void Update()
    {
        for (int i = 0; i < 2; i++)
        {
            music[i].volume = 0.1f;
        }
        
        //Fade songs based on the worldState 
        if (gameManager.levelManager.worldState)
        {
            FadeIn(music[0]);
            FadeOut(music[1]);
        }
        else
        {
            FadeIn(music[1]);
            FadeOut(music[0]);
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

    #region Explosion
    public void PlayExplosionSound()
    {
        soundFX[0].Play();
    }
    #endregion

    #region Jump
    public void PlayJumpSound()
    {
        soundFX[1].Play();
    }
    #endregion
}
