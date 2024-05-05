using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float countdown;
    public GameObject fireballPrefab;
    public Transform owner;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown < 0)
        {
            countdown = 3f;
            Fire();
        }
    }

    void Fire()
    {
        Instantiate(fireballPrefab, owner.localPosition, owner.rotation, owner);
    }
}
