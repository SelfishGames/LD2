using UnityEngine;
using System.Collections;

public class EndPlayer : MonoBehaviour
{
    public GameManager gameManager;
    public float force;
    private bool jumping = false;

    void start()
    {
       

    }

    // Update is called once per frame
    void Update ()
    {

        Physics.gravity = new Vector3(0, -50, 0);
        if(gameManager.levelLoading)
        {
            transform.Rotate(Vector3.up, Time.deltaTime * 150);
            if(!jumping)
            {
                rigidbody.AddForce(new Vector3(0, force, 0), ForceMode.Impulse);
                
                jumping = true;
            }

            if (transform.position.y >= 5)
            {
                jumping = true;
            }

            if (transform.position.y <= 2.23)
            {
                jumping = false;
            }
        }
    }
}
