using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour 
{
    public GameManager gameManager;

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
        transform.position = new Vector3(-24, 2.3f, -1);
    }

    #region OnCollisionEnter
    void OnCollisionEnter(Collision col)
    {
        //If the player has landed 
        if (col.gameObject.name == "FloorCeiling" && isJumping)
            isJumping = false;
    }
    #endregion
}
