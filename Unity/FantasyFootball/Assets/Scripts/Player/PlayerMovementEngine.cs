using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementEngine : MonoBehaviour 
{
    private Rigidbody movementRoot; //rigidbody that handles all player movement
    
	// Use this for initialization
	void Start () {
        movementRoot = transform.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        
	}
}
