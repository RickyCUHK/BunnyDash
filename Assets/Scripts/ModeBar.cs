using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeBar : MonoBehaviour
{
    public GameObject f1;
    public GameObject f2;
    public GameObject f3;
    public GameObject v1;
    public GameObject v2;
    public GameObject v3;
    public GameObject i1;
    public GameObject i2;
    public GameObject i3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Status.fireCount == 1)
        {
            UnableAll();
            f1.SetActive(true);
        }
        else if (Status.fireCount == 2)
        {
            UnableAll();
            f1.SetActive(true);
            f2.SetActive(true);
        }
        else if (Status.fireCount == 3)
        {
            UnableAll();
            f1.SetActive(true);
            f2.SetActive(true);
            f3.SetActive(true);
        }

        if (Status.voltCount == 1)
        {
            UnableAll();
            v1.SetActive(true);
        }
        else if (Status.voltCount == 2)
        {
            UnableAll();
            v1.SetActive(true);
            v2.SetActive(true);
        }
        else if (Status.voltCount == 3)
        {
            UnableAll();
            v1.SetActive(true);
            v2.SetActive(true);
            v3.SetActive(true);
        }

        if (Status.iceCount == 1)
        {
            UnableAll();
            i1.SetActive(true);
        }
        else if (Status.iceCount == 2)
        {
            UnableAll();
            i1.SetActive(true);
            i2.SetActive(true);
        }
        else if (Status.iceCount == 3)
        {
            UnableAll();
            i1.SetActive(true);
            i2.SetActive(true);
            i3.SetActive(true);
        }
    }

    void UnableAll()
    {
        f1.SetActive(false);
        f2.SetActive(false);
        f3.SetActive(false);
        v1.SetActive(false);
        v2.SetActive(false);
        v3.SetActive(false);
        i1.SetActive(false);
        i2.SetActive(false);
        i3.SetActive(false);
    }
}
