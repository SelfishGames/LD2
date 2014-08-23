using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour
{
    public Transform player;
    public Transform pivot;

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
                Debug.Log("World 1 returned true");
                return true;
            }
        }
        else if (worlds == 2)
        {
            if (transform.eulerAngles.x >= 85)
            {
                Debug.Log("World 2 returned true");
                return true;
            }
        }

        transform.LookAt(pivot);
        transform.Translate(direction * Time.deltaTime * 50);
        Debug.Log(transform.eulerAngles);

        return false;
    }
}

