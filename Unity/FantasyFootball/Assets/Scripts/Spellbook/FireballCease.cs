using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is just a placeholder script so I had something to pool, but it might be worth keeping about for reference
public class FireballCease : MonoBehaviour {
    // This avoids the enaction of a destroy function, instead just Ceasing the bullet from being active
    void OnEnable()
    {
        Invoke("Cease", 0.5f);
    }

    void Cease()
    {
        gameObject.SetActive(false);
    }

    // Just making sure no active Invokes cause fuckery
    void OnDisable()
    {
        CancelInvoke();
    }
}
