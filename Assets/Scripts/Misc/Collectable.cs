using UnityEngine;
using System.Collections;

public class Collectable : MonoBehaviour
{

    #region Fields
    public GameManager gameManager;

    private float speed;
    #endregion

    // Use this for initialization
    void Start()
    {
        speed = Random.Range(40, 100);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, speed * Time.deltaTime);
        transform.Rotate(Vector3.right, speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider col)
    {
        gameManager.bonusManager.tempCollected += 1;
        gameManager.bonusManager.collected += 1;
        gameManager.soundManager.soundFX[2].Play();
        gameObject.SetActive(false);
    }
}
