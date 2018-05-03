using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< HEAD
public class PlayerMovementEngine : MonoBehaviour
=======
public class PlayerMovementEngine : MonoBehaviour 
>>>>>>> master
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
