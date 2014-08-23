using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour
{
    public Transform player;
    public Transform pivot;
    public Transform target;

    private Vector3 tempPos;

    void Start()
    {
        tempPos = transform.position;
    }

    void Update()
    {
        tempPos.x = player.position.x;
        transform.position = tempPos;

    }

    public bool ChangeView(int worlds, Vector3 direction)
    {
        if (worlds == 1)
        {
            if (transform.eulerAngles.x <= 5)
            {
                return true;
            }
        }
        else if (worlds == 2)
        {
            if (transform.eulerAngles.x >= 85)
            {
                return true;
            }
        }

        transform.LookAt(pivot);
        transform.Translate(direction * Time.deltaTime * 50);

        return false;
    }
}

