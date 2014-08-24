using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour 
{
    public GameManager gameManager;
    public Vector3 startPos;
    public float speed;

    private Vector3 tempPos;

    private bool justJumped = false;
    private int jumpCount = 0;

    #region FixedUpdate
    void FixedUpdate()
    {
        if (gameManager.levelManager.worldState)
        {
            rigidbody.AddForce(Input.GetAxis("Horizontal") * speed, 0, Input.GetAxis("Vertical") * speed);
        }
        else
        {
            rigidbody.AddForce(Input.GetAxis("Horizontal") * speed, 0, 0);

            if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 2)
            {
                justJumped = true;
                jumpCount++;
                rigidbody.AddForce(Vector3.up * 600);
                gameManager.soundManager.soundFX[1].Play();
            }
        }

        RaycastHit hit;
        if (!Physics.Raycast(transform.position, Vector3.down, out hit, 1f) && justJumped)
        {
            justJumped = false;
        }

        if(!justJumped)
        {
            if (Physics.Raycast(transform.position, Vector3.down, out hit, 1f))
                jumpCount = 0;
        }
    }
    #endregion

    public void ResetPlayer()
    {
        gameManager.playerExplosion.SetActive(false);
        rigidbody.velocity = Vector3.zero;
        transform.position = startPos;
    }

    #region OnCollisionEnter
    void OnCollisionEnter(Collision col)
    {

    }
    #endregion
}
