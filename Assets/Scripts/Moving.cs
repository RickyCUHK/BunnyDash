using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    public float speed;

    public static float realSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        realSpeed = speed;
        transform.position = new Vector3(transform.position.x - realSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        if (transform.position.x < -15) Destroy(gameObject);
    }
}
