using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crocodile : MonoBehaviour
{
    public GameObject itself;
    public GameObject particle;
    public GameObject eliminateSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Rabbit") //HIt by rabiit
        {
            Instantiate(eliminateSound);
            Instantiate(particle, itself.transform.position, Quaternion.identity);
            Status.killNumber += 1;
            Destroy(itself);

            if (gameObject.tag == "fire")
            {
                Status.fireCount += 1;
                Status.iceCount = 0;
                Status.voltCount = 0;
            }
            if (gameObject.tag == "ice")
            {
                Status.fireCount = 0;
                Status.iceCount += 1;
                Status.voltCount = 0;
            }
            if (gameObject.tag == "volt")
            {
                Status.fireCount = 0;
                Status.iceCount = 0;
                Status.voltCount += 1;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
