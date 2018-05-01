using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlEngine : MonoBehaviour 
{
    //this sucks, will need to be improved when we know what we're doing
    public GameObject[] spellBook = new GameObject[4]; //contains the spell prefabs the player can use within the match

    private bool useGamepad; //should be changed when receiving input from a gamepad / mouse

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}