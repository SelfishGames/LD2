using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour
{

    private Vector3 input;
    public float moveSpeed;
    private float maxSpeed = 15f;


    #region Fields
    public GameManager gameManager;
    public Vector3 startPos;
    public float speed;
    public GameObject[] particleSystems;

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
            if (Physics.Raycast(transform.position, (Vector3.down + Vector3.right).normalized, out hit, 1.5f) ||
                (Physics.Raycast(transform.position, (Vector3.down + Vector3.left).normalized, out hit, 1.5f)))
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
