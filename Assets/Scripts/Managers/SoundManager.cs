using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour
{
    #region Fields
    public List<AudioSource> soundFX;
    public List<AudioSource> music;
    #endregion

    #region Start
    void Start()
    {
        music[0].Play();
    }
    #endregion

    #region Update
    void Update()
    {

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
