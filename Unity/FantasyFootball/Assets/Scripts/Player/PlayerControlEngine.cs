using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlEngine : MonoBehaviour 
{
    enum State { Running, Channeling, Kicking, Stunned, Airborne };

    public PlayerCameraEngine cameraEngine;
    public PlayerMovementEngine movementEngine;

    private bool useGamepad; //should be changed when receiving input from a gamepad / mouse

    public bool inputEnabled;
    State currentState;
    public GameObject controlledBall; //null is no ball
    
    private Vector3 mouseWorldPosition;

    public LayerMask layer_mask;

    // Use this for initialization
    void Start () {

    }

    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 1000, layer_mask.value))
        {
            Transform objectHit = hit.transform;
            mouseWorldPosition = hit.point;
        }

            Debug.DrawRay(ray.origin, ray.direction * 32, Color.yellow);
        
            Debug.DrawRay(mouseWorldPosition, Vector3.up*10, Color.yellow);

        movementEngine.moveInput.x = Input.GetAxisRaw("Horizontal");
        movementEngine.moveInput.z = -Input.GetAxisRaw("Vertical");
        movementEngine.moveInput.Normalize();
        
        Vector3 vec = mouseWorldPosition - movementEngine.movementRoot.transform.position;

        movementEngine.aimTarget = mouseWorldPosition;
    }

    void CheckIsGrounded()
    {
        //Physics.Linecast
    }

    void Kick(float power)
    {
        
    }
}