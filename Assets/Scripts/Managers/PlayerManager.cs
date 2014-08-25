using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour
{
    #region Fields
    public GameManager gameManager;
    public Vector3 startPos;
    public float speed;
    public GameObject[] particleSystems;

    private Vector3 tempPos;

    private bool isJumping = false;

    private Vector3 rightRay,
        leftRay;
    #endregion

    #region Field
    void Start()
    {
        rightRay = (Vector3.down + new Vector3(0.5f, 0, 0));
        leftRay = (Vector3.down + new Vector3(-0.5f, 0, 0));
    }
    #endregion

    #region Update
    void Update()
    {
        Debug.DrawRay(transform.position, rightRay, Color.red);
    }
    #endregion

    #region FixedUpdate
    void FixedUpdate()
    {
        //If the mainCamera is active
        if (gameManager.cameraManager.gameObject.activeSelf == true)
        {
            //Top-down controls
            if (gameManager.levelManager.worldState)
            {
                rigidbody.velocity = new Vector3(Input.GetAxis("Horizontal") * speed, 0, Input.GetAxis("Vertical") * speed);
            }
            //Side-on controls
            else
            {
                rigidbody.velocity = new Vector3(Input.GetAxis("Horizontal") * speed, rigidbody.velocity.y, 0);

                //Player jump
                if (Input.GetKey(KeyCode.Space) && !isJumping)
                {
                    rigidbody.velocity = new Vector3(rigidbody.velocity.x, 17, rigidbody.velocity.z);

                    InvokeRepeating("CheckForFloor", 1f, 0.1f);

                    isJumping = true;
                    gameManager.soundManager.PlayJumpSound();
                }
            }
        }
    }
    #endregion

    #region CheckForFloor
    void CheckForFloor()
    {
        if (isJumping)
        {
            //Sends two raycasts below and to the sides of the player to check for a floor
            RaycastHit hit;
            if (Physics.Raycast(transform.position, rightRay, out hit, 1.7f) ||
                (Physics.Raycast(transform.position, leftRay, out hit, 1.7f)))
            {
                isJumping = false;
                CancelInvoke();
            }
        }
    }
    #endregion

    #region ResetPlayer
    public void ResetPlayer()
    {
        //Deactivates the player particles
        for (int i = 0; i < 2; i++)
        {
            gameManager.particleSystems[i].SetActive(false);
        }
            
        //Respawns the player at the start of the room with no velocity
        rigidbody.velocity = Vector3.zero;
        transform.position = startPos;

        //Puts the worldState back in top-down
        gameManager.levelManager.worldState = true;
    }
    #endregion
}
