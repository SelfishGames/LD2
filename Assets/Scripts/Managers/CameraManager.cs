using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour
{
    #region Fields
    public Transform player;

    private Vector3 tempPos,
        sideOffset,
        topOffset,
        pivot,
        target;

    private float delay = 5;

    private Quaternion tempEuler;
    #endregion 

    #region Start
    void Start()
    {
        //Sets the initial points of pivot and offset positions
        pivot = new Vector3(player.position.x, 8f, 0f);
        topOffset = new Vector3(player.position.x, 30f, 0f);
        sideOffset = new Vector3(player.position.x, 8f, -30f);
    }
    #endregion

    #region Update
    void Update()
    {
        //Sets the pivot & offset positions x to follow the player
        //(Clamps the pivot & camera x to not go beyond the level)
        pivot.x = Mathf.Clamp(player.position.x, -16.5f, 19f);
        topOffset.x = player.position.x;
        sideOffset.x = player.position.x;

        tempPos = transform.position;
        tempPos.x = Mathf.Clamp(player.position.x, -16.5f, 19f); 
        transform.position = tempPos;

        transform.LookAt(pivot);
    }
    #endregion

    #region StartLerp
    public void StartLerp(int i)
    {
        //Int i is basically if the camera is going from top to side 
        //or vis versa
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
    #endregion

    #region LerpCamera
    IEnumerator LerpCamera()
    {
        //Lerps the camera until the delay time has been reached
        float startTime = Time.time;
        while (Time.time < startTime + delay)
        {
            transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime * 1.5f);
            yield return null;
        }
    }
    #endregion
}

