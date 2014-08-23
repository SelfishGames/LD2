﻿using UnityEngine;
using System.Collections;

public class EndLevel : MonoBehaviour
{    
    public GameManager gameManager;
    // Update is called once per frame
    void Update ()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        gameManager.playerManager.gameObject.SetActive(false);
        gameManager.TriggerCollision();
        StartCoroutine(ExplosionDelay (col));	
    }

    IEnumerator ExplosionDelay(Collider col)
    {
        yield return new WaitForSeconds(2f);
        gameManager.cameraManager.transform.GetChild(0).gameObject.SetActive(true);

        gameManager.playerManager.ResetPlayer();
        gameManager.levelManager.currentLevel++;
        gameManager.levelManager.ArrangeObstacles();
    }
}
