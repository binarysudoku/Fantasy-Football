using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlEngine : MonoBehaviour 
{
    public PlayerCameraEngine cameraEngine;
    public PlayerMovementEngine movementEngine;

    public GameObject controlledBall;
    
    //this sucks, will need to be improved when we know what we're doing
    public GameObject[] spellBook = new GameObject[4]; //contains the spell prefabs the player can use within the match

    private bool useGamepad; //should be changed when receiving input from a gamepad / mouse
    
    private Vector3 mouseWorldPosition;

    public LayerMask layer_mask;

    // Use this for initialization
    void Start () {

    }

    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, layer_mask))
        {
            Transform objectHit = hit.transform;

            // Do something with the object that was hit by the raycast.
            mouseWorldPosition = hit.point;
        }

        Debug.DrawRay(ray.origin, ray.direction * 16, Color.yellow);
        
        Debug.DrawRay(mouseWorldPosition, Vector3.up*10, Color.yellow);

        movementEngine.moveInput.x = -Input.GetAxis("Horizontal");
        movementEngine.moveInput.z = Input.GetAxis("Vertical");
    }
}