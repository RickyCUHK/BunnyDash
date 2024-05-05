using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eat : MonoBehaviour
{
    public GameObject hurtAudio;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Rabbit")
        {
            Instantiate(hurtAudio);
            Status.health -= 1;
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 500f);
            Camera.main.GetComponent<CameraShake>().enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void noCollision()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }
}
