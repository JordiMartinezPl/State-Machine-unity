using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject target;
    private float targetPoseX;
    private float targetPoseY;

    private float poseX;
    private float poseY;

    public float rightMax;
    public float leftMax;

    public float hightMax;
    public float highMin;

    public float speed;

    public bool enableCamera = true;


    public void Awake()
    {
        poseX = targetPoseX + leftMax;
        poseY = targetPoseY + hightMax;
        transform.position = Vector3.Lerp(transform.position, new Vector3(poseX, poseY, -1), 1);
    }

    private void Update()
    {
        moveCamera();
    }

    void moveCamera()
    {
        if (enableCamera)
        {
            if (target)
            {

                targetPoseX = target.transform.position.x;
                targetPoseY = target.transform.position.y;
                if (targetPoseX > leftMax && targetPoseX < rightMax)
                {
                    poseX = targetPoseX;
                }

                if (targetPoseY < hightMax && targetPoseY > highMin)
                {

                    poseY = targetPoseY;
                }
            }
            transform.position = Vector3.Lerp(transform.position, new Vector3(poseX, poseY, -1), speed * Time.deltaTime);
        }
    }
}
