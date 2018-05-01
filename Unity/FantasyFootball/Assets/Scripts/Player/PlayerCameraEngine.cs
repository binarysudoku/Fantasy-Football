using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraEngine : MonoBehaviour
{

    public Transform playerRoot;
    public Transform mainCamera;

    public float camSpeed = 1f; //speed to interpolate camera position
    public float zoomSpeed = 1f;
    public float aimOffsetDistance = 4f; //distance to offset camera toward aim direction
    public Vector3 cameraAngle = new Vector3(-60,0,0); //camera angle
    public Vector3 defaultOffset = new Vector3(0, 0, 20); //default zoom distance

    //internal variables
    private bool followBall; //whether the camera should follow the ball
    private Vector3 targetPos; //current target position
    private Vector3 targetOffset; //current zoom in units

    // Use this for initialization
    void Start()
    {
        transform.eulerAngles = cameraAngle;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCamTarget();
        
        //lerp root transform toward target position
        transform.position = Vector3.Lerp(transform.position, targetPos, camSpeed);

        //lerp camera transform toward target offset
        mainCamera.localPosition = Vector3.Lerp(mainCamera.localPosition, targetOffset, zoomSpeed);

        //DEBUG
        Debug.DrawRay(targetPos, Vector3.up * 10, Color.green);
        Debug.DrawRay(transform.position, Vector3.up * 10, Color.red);
    }

    void UpdateCamTarget()
    {
        //placeholder code, currently only follows player; needs improvement
        targetOffset = defaultOffset;
        targetPos = playerRoot.transform.position;
    }
}