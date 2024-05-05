using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabbit : MonoBehaviour
{
    public Rigidbody2D rabbit;
    public Transform[] jumpPoint;
    public float speed;
    public float jumpForce;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
        for (int i = 0; i< jumpPoint.Length; i++)
        {
            if ((transform.position.x-jumpPoint[i].position.x)<0.1 && (transform.position.x - jumpPoint[i].position.x) > -0.1)
            {
                Jump();
            }
        }
        
    }

    void Jump()
    {
        rabbit.AddForce(Vector2.up * jumpForce);
    }
}
