using UnityEngine;
using System.Collections;

public class WorldDay : MonoBehaviour
{
    public GameManager gameManager;

    private Color tempColour;

    void Start()
    {
        tempColour = transform.renderer.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManager.levelManager.worldState)
        {
            StartCoroutine(RemoveCollider(false));
            transform.renderer.material.color = Color.Lerp(
                        transform.renderer.material.color, Color.clear, Time.deltaTime);
            
        }

        else
        {
            StartCoroutine(RemoveCollider(true));
            transform.renderer.material.color = Color.Lerp(
                        transform.renderer.material.color, tempColour, Time.deltaTime);
            
        }
    }

    IEnumerator RemoveCollider(bool change)
    {
        yield return new WaitForSeconds(2);
        collider.enabled = change;
    }
}
