using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour 
{
    public GameManager gameManager;
    public Vector3 startPos;
    public float speed;

    private Vector3 tempPos;

    private bool isJumping = false;

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

            if (Input.GetKey(KeyCode.UpArrow) && !isJumping)
            {
                isJumping = true;
                rigidbody.AddForce(Vector3.up * 700);
                gameManager.soundManager.soundFX[1].Play();
            }
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
        //If the player has landed 
        if (col.gameObject.tag == "Obs" && isJumping)
            isJumping = false;
    }
    #endregion
}
