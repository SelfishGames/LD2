using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour 
{
    public GameManager gameManager;

    public float speed;

    private Vector3 tempPos;

	void Start () 
    {
	
	}
	
	void Update () 
    {

	}

    #region FixedUpdate
    void FixedUpdate()
    {
        if (gameManager.levelManager.worldState)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
                rigidbody.AddForce(Vector3.left * speed);
            if (Input.GetKey(KeyCode.RightArrow))
                rigidbody.AddForce(Vector3.right * speed);

            if (Input.GetKey(KeyCode.UpArrow))
                rigidbody.AddForce(Vector3.forward * speed);
            if (Input.GetKey(KeyCode.DownArrow))
                rigidbody.AddForce(Vector3.back * speed);
        }
        else
        {
            if (Input.GetKey(KeyCode.LeftArrow))
                rigidbody.AddForce(Vector3.left * speed);
            if (Input.GetKey(KeyCode.RightArrow))
                rigidbody.AddForce(Vector3.right * speed);

            if (Input.GetKey(KeyCode.UpArrow))
                rigidbody.AddForce(Vector3.up * speed);
            if (Input.GetKey(KeyCode.DownArrow))
                rigidbody.AddForce(Vector3.down * speed);
        }
    }
    #endregion
}
