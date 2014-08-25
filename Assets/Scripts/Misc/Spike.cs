using UnityEngine;
using System.Collections;

public class Spike : MonoBehaviour
{
    public GameManager gameManager;

    private Color tempColour;

    void Start()
    {
        tempColour = transform.renderer.material.color;
    }

    void Update()
    {
        if (!gameManager.levelManager.worldState)
        {
            StartCoroutine(RemoveCollider(true));
            transform.renderer.material.color = Color.Lerp(
                        transform.renderer.material.color, tempColour, Time.deltaTime);
        }

        else
        {
            StartCoroutine(RemoveCollider(false));
            transform.renderer.material.color = Color.Lerp(
                        transform.renderer.material.color, Color.clear, Time.deltaTime);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Player")
        {
            gameManager.playerManager.gameObject.SetActive(false);
            gameManager.TriggerCollision(0);
            StartCoroutine(ExplosionDelay());
        }
    }

    IEnumerator ExplosionDelay()
    {
        yield return new WaitForSeconds(2f);

        gameManager.playerManager.ResetPlayer();
        gameManager.player.gameObject.SetActive(true);
    }


    IEnumerator RemoveCollider(bool change)
    {
        yield return new WaitForSeconds(2);
        collider.enabled = change;
    }
}