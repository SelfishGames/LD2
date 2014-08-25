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

    void Start()
    {
        rightRay = (Vector3.down + new Vector3(0.5f, 0, 0));
        leftRay = (Vector3.down + new Vector3(-0.5f, 0, 0));
    }

    #region Update
    void Update()
    {
        Debug.DrawRay(transform.position, rightRay, Color.red);
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

            if (Input.GetKey(KeyCode.Space) && !isJumping)
            {
                rigidbody.velocity = new Vector3(rigidbody.velocity.x, 15, rigidbody.velocity.z);
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
            if (Physics.Raycast(transform.position, rightRay, out hit, 1.7f) ||
                (Physics.Raycast(transform.position, leftRay, out hit, 1.7f)))
            {
                isJumping = false;
                CancelInvoke();
            }
        }
    }

    #region ResetPlayer
    public void ResetPlayer()
    {
        for (int i = 0; i < 2; i++)
        {
            gameManager.particleSystems[i].SetActive(false);
        }
            
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
