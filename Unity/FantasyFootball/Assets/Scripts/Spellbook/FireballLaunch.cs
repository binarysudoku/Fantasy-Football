using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballLaunch : MonoBehaviour {

    public float fireTime = 1.5f;
    public GameObject fireball;
    // Number of Fireballs loaded on launch - one for each WIZARD (∩｀-´)⊃━☆ﾟ.*･｡ﾟ
    public int pooledAmount = 6;
    List<GameObject> fireballs;

    // Creates a list of each Fireball to be called on later
    void Start()
    {
        fireballs = new List<GameObject>();
        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(fireball);
            obj.SetActive(false);
            fireballs.Add(obj);
        }

        Invoke("CastFireball", fireTime);
    }

    void CastFireball()
    {
        for (int i = 0; i < fireballs.Count; i++)
        {
            if (!fireballs[i].activeInHierarchy)
            {
                fireballs[i].transform.position = transform.position;
                fireballs[i].transform.rotation = transform.rotation;
                fireballs[i].SetActive(true);
                break;
            }
        }
    }
}

