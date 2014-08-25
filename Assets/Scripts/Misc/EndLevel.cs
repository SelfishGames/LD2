using UnityEngine;
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
        gameManager.soundManager.endLevel.Play();
        StartCoroutine(ExplosionDelay (col));
        gameManager.levelLoading = true;
        gameManager.currentState = 0;
        gameManager.levelManager.currentLevel++;
    }

    IEnumerator ExplosionDelay(Collider col)
    {
        yield return new WaitForSeconds(1.5f);
        
        gameManager.playerManager.ResetPlayer();
        
        gameManager.levelManager.ArrangeObstacles();
        gameManager.bonusManager.tempCollected = 0;
        gameManager.bonusManager.collected = 0;
    }
}
