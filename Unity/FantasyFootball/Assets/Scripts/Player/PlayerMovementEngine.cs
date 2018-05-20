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

    [Header("Movement")]
    public float moveSpeed;

    public Vector3 moveInput = new Vector3(0,0,0);

    [Header("Turning")]
    public float aimAcceleration;

    public Vector3 aimTarget = new Vector3(0,0,0);

    [Header("Tackling")]

    public Rigidbody movementRoot; //rigidbody that handles all player movement
    
	// Use this for initialization
	void Start () {
        movementRoot = transform.GetComponent<Rigidbody>();
        
        //movementRoot.mass *= timeScale;
        //rigidbody.velocity /= timeScale;
        //rigidbody.angularVelocity /= timeScale;
    }
	
	// Update is called once per frame
	void Update () {
        
    }
    
    // FixedUpdate is called independently of framerate, all physics should be handled here
    void FixedUpdate ()
    {
        float delta = Time.fixedDeltaTime * timeScale;
        AddMovement(moveInput);

        //replace with 2d calculation
        Vector3 target = aimTarget - movementRoot.transform.position;
        float step = aimAcceleration * Time.deltaTime;
        Vector3 newDir = Vector3.RotateTowards(movementRoot.transform.forward, target, step, 0.0f);
        newDir.y = 0;
        movementRoot.transform.rotation = Quaternion.LookRotation(newDir);

        //movementRoot.transform.rotation.RotateTowards(movementRoot.transform.rotation,new Vector3(0,aimInput,0),360,2);

        //compensates for gravity problems when running in slow/fast motion
        //movementEngine.movementRoot.velocity += Physics.gravity / rigidbody.mass * delta;
    }
    
    public void AddMovement (Vector3 direction)
    {
        movementRoot.velocity = moveInput * moveSpeed;
        //AddForce(direction * moveAcceleration);
    }
    
    public void AdjustPhysicsTimescale()
    {
        
    }

    void Kick(Ball ball, float power)
    {
        ball.rb.AddForce(movementRoot.transform.forward * power);
    }
}
