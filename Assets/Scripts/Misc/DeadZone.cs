using UnityEngine;
using System.Collections;

public class DeadZone : MonoBehaviour
{
    public GameManager gameManager;

    // Use this for initialization
    void Start ()
    {

    }

    // Update is called once per frame
    void Update ()
    {

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Player")
        {

            gameManager.playerManager.gameObject.SetActive(false);
            gameManager.TriggerCollision();
            StartCoroutine(ExplosionDelay());
        }
    }

    IEnumerator ExplosionDelay()
    {
        yield return new WaitForSeconds(2f);

        gameManager.playerManager.ResetPlayer();
        gameManager.player.gameObject.SetActive(true);
    }
}
