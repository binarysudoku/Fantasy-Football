using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionEngine : MonoBehaviour {

    public Ball activeBall;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        //check if tag is "Ball"
        if (other.GetComponent<Ball>() != null)
        {
            Debug.Log("this is a ball");
            activeBall = other.GetComponent<Ball>();
            Debug.Log(other.GetComponent<Ball>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Ball>() != null)
        {
            activeBall = null;
        }
    }
}
