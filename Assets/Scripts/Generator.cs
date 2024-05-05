using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public Transform position1;
    public Transform position2;
    public Transform position3;
    public float N_countDown;
    public float F_countDown;
    public float I_countDown;
    public float countDown;
    public GameObject landPrefab;
    public GameObject crockPrefab;
    public GameObject F_crockPrefab;
    public GameObject V_crockPrefab;
    public GameObject I_crockPrefab;
    public Transform holder;

    private float initalCount0;
    private float initalCount1;
    private float initalCount2;
    private float initalCount3;
    private float[] landGenerator;
    private float[] crockGenerator;
    private float counter;
    private int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        initalCount0 = countDown;
        initalCount1 = N_countDown;
        initalCount2 = F_countDown;
        initalCount3 = I_countDown;
    }

    // Update is called once per frame
    void Update()
    {
        if (countDown <= 0)
        {
            GenerateLand(count);
            countDown = initalCount0;
        }
        if (N_countDown <= 0)
        {
            GenerateCrock();
            N_countDown = initalCount1;
        }
        if (F_countDown <= 0)
        {
            GenerateF_Crock();
            F_countDown = initalCount2;
        }
        if (I_countDown <= 0)
        {
            GenerateI_Crock();
            I_countDown = initalCount3;
        }
    }

    private void FixedUpdate()
    {
        counter += Time.deltaTime;
        countDown -= Time.deltaTime;
        F_countDown -= Time.deltaTime;
        N_countDown -= Time.deltaTime;
        I_countDown -= Time.deltaTime;
    }

    void GenerateLand(int count)
    {
        if (count == 0)
        {
            GameObject t_land = Instantiate(landPrefab, position1.localPosition, position1.rotation, holder);
            t_land.transform.localScale = Vector3.one;
        }
        else if (count == 1) Instantiate(landPrefab, position2.localPosition, position1.rotation, holder);
        else Instantiate(landPrefab, position3.localPosition, position1.rotation, holder);
    }

    void GenerateCrock()
    {
        Instantiate(crockPrefab, position2.localPosition, position1.rotation, holder);
        Instantiate(V_crockPrefab, position3.localPosition, position1.rotation, holder);
    }

    void GenerateF_Crock()
    {
        Instantiate(F_crockPrefab, position2.localPosition, position1.rotation, holder);
    }

    void GenerateI_Crock()
    {
        Instantiate(I_crockPrefab, position2.localPosition, position1.rotation, holder);
    }
}
