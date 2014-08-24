using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour
{
    #region Fields
    public GameManager gameManager;
    public Vector3 startPos;
    public float speed;

    private Vector3 tempPos;

    private bool isJumping = false;
    #endregion

    void Start()
    {

    }

    #region Update
    void Update()
    {
        
    }
    #endregion

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

            if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
            {
                rigidbody.AddForce(Vector3.up * 600);
                InvokeRepeating("CheckForFloor", 1f, 0.1f);
                isJumping = true;
                gameManager.soundManager.PlayJumpSound();
            }
        }
    }
    #endregion

    void CheckForFloor()
    {
        if (isJumping)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.5f))
            {
                isJumping = false;
                CancelInvoke();
            }
        }
    }

    #region ResetPlayer
    public void ResetPlayer()
    {
        gameManager.playerExplosion.SetActive(false);
        rigidbody.velocity = Vector3.zero;
        transform.position = startPos;
    }
    #endregion

    #region OnCollisionEnter
    void OnCollisionEnter(Collision col)
    {

    }
    #endregion
}
