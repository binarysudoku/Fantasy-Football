using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementEngine : MonoBehaviour 
{
    [Header("Physics")]
    public float timeScale = 1;
    public float playerMass = 1;
    public float playerVelocity = 0;
    public float playerAngular = 0;

    private bool isGrounded = true;

    [Header("Movement")]
    public float moveSpeed;

    public Vector3 moveInput = new Vector3(0,0,0);

    [Header("Turning")]
    public float aimAcceleration;
    private float aimAngle = 0;

    private float aimInput = 0;

    [Header("Tackling")]

    protected Rigidbody movementRoot; //rigidbody that handles all player movement
    
	// Use this for initialization
	void Start () {
        movementRoot = transform.GetComponent<Rigidbody>();
        
        //movementRoot.mass *= timeScale;
        //rigidbody.velocity /= timeScale;
        //rigidbody.angularVelocity /= timeScale;
    }
	
	// Update is called once per frame
	void Update () {
        AddMovement(moveInput);
    }
    
    // FixedUpdate is called independently of framerate, all physics should be handled here
    void FixedUpdate ()
    {
        float delta = Time.fixedDeltaTime * timeScale;

        

        //compensates for gravity problems when running in slow/fast motion
        //movementEngine.movementRoot.velocity += Physics.gravity / rigidbody.mass * delta;
    }
    
    public void AddMovement (Vector3 direction)
    {
        movementRoot.velocity = new Vector3(Input.GetAxis("Horizontal")*moveSpeed,movementRoot.velocity.y,-Input.GetAxis("Vertical")* moveSpeed);
        //AddForce(direction * moveAcceleration);
    }

    public void AdjustPhysicsTimescale()
    {
        
    }
}
