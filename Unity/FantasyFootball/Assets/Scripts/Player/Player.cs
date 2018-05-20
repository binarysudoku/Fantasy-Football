using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour 
{
    enum State { Running, Channeling, Kicking, Stunned, Airborne };

    public string playerName;
    
    private bool useGamepad; //should be changed when receiving input from a gamepad / mouse

    public PlayerCameraEngine cameraEngine;
    public PlayerMovementEngine movementEngine;
    public PlayerInteractionEngine interactionEngine;

    public Collider pickupCollider;
    
    private State currentState;
    
    private Vector3 mouseWorldPosition;
    public LayerMask layer_mask; //layer mask for checking mouse aim
    
    private bool InputEnabled
    {
        get
        {
            return InputEnabled;
        }

        set
        {
            InputEnabled = value;
        }
    }

    // Use this for initialization
    void Start () {

    }

    void Update()
    {
        HandleMovementInput();

        HandleBallInput();
    }

    void HandleMovementInput()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 1000, layer_mask.value))
        {
            Transform objectHit = hit.transform;
            mouseWorldPosition = hit.point;
        }
        
        movementEngine.moveInput.x = Input.GetAxisRaw("Horizontal");
        movementEngine.moveInput.z = -Input.GetAxisRaw("Vertical");
        movementEngine.moveInput.Normalize();
        
        movementEngine.aimTarget = mouseWorldPosition;

        Debug.DrawRay(ray.origin, ray.direction * 32, Color.yellow);
        Debug.DrawRay(mouseWorldPosition, Vector3.up * 10, Color.yellow);
    }

    void HandleBallInput()
    {
        Ball ball = interactionEngine.activeBall;
        if (ball != null)
        {
            ball = interactionEngine.activeBall;
            if (ball.activePlayer != this)
            {
                ball.activePlayer = this;
            }

            Vector3 dir = Vector3.Normalize(interactionEngine.transform.position - ball.transform.position);

            ball.rb.MovePosition(interactionEngine.transform.position);

            if (Input.GetButton("Kick"))
            {
                Debug.Log("kicking");
            }

            if (Input.GetButton("Pass"))
            {
                Debug.Log("passing");
            }
        }
    }
}