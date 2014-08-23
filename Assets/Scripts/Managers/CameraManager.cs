using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour
{
    public Transform player;

    private Vector3 tempPos,
        sideOffset,
        topOffset,
        pivot,
        target;

    private float delay;

    private Quaternion tempEuler;

    void Start()
    {
        pivot.y = 6f;
        pivot.z = 0f;

        delay = 5;
    }

    void Update()
    {
        pivot.x = player.position.x;

        tempPos = transform.position;
        tempPos.x = player.position.x;
        transform.position = tempPos;

        transform.LookAt(pivot);

        topOffset = new Vector3(player.position.x, 30f, 0f);
        sideOffset = new Vector3(player.position.x, 6f, -30f);
    }

    public void StartLerp(int i)
    {
        if (i == 1)
        {
            target = sideOffset;
            StopCoroutine(LerpCamera());
        }
        else if (i == 2)
        {
            target = topOffset;
            StopCoroutine(LerpCamera());
        }

        StartCoroutine(LerpCamera());
    }

    IEnumerator LerpCamera()
    {
        float startTime = Time.time;
        while (Time.time < startTime + delay)
        {
            transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime);
            yield return null;
        }
    }
}

