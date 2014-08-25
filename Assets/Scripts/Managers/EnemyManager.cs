using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float speed;
    public GameManager gameManager;
    public bool isEndEnemy;

    private Color tempColour;
    private int currentArea = 0;


    void Start()
    {
        tempColour = transform.renderer.material.color;
        transform.position = patrolPoints[0].position;
        currentArea = 0;
    }

    void Update()
    {
        if (gameManager.levelManager.worldState)
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

        if(transform.position == patrolPoints[currentArea].position)
        {
            currentArea++;
        }

        if (currentArea >= patrolPoints.Length)
        {
            currentArea = 0;
        }

        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[currentArea].position, speed * Time.deltaTime);
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


    IEnumerator RemoveCollider(bool change)
    {
        yield return new WaitForSeconds(2);
        collider.enabled = change;
    }
}