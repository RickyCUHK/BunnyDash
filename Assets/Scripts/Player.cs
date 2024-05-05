using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public float strikeForce;
    public Rigidbody2D rig;
    public Transform owner;
    public Transform groundDetector;
    public LayerMask ground;
    public GameObject normalmode;
    public GameObject firemode;
    public GameObject voltmode;
    public GameObject icemode;
    public GameObject fireballPrefab;
    public float fireCD = 3f;

    private int modeNumber = 0;
    private bool doubleJumped = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switchMode(Status.modeNumber);
        fireCD -= Time.deltaTime;
    }

    void Update()
    {
        bool isGrounded = Physics2D.Raycast(groundDetector.position, Vector2.down, 0.2f, ground);
        if (isGrounded)
        {
            doubleJumped = false; //重置二段跳
            setAnimator(modeNumber, false);
        }
        float t_hmove = Input.GetAxis("Horizontal");
        // if (t_hmove == 1) rig.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        rig.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        rig.velocity = new Vector2(t_hmove * speed, rig.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space)) // Jump
        {
            if (isGrounded)
            {
                GetComponent<AudioSource>().Play();
                rig.AddForce(Vector2.up * jumpForce);
                setAnimator(modeNumber, true);
            }
            else if (modeNumber == 2)
            {
                if (!doubleJumped)
                {
                    GetComponent<AudioSource>().Play();
                    rig.AddForce(Vector2.up * jumpForce);
                    doubleJumped = true;
                    setAnimator(modeNumber, true);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            rig.AddForce(Vector2.down * strikeForce);
        }

        if (Input.GetKeyDown(KeyCode.E) && modeNumber == 1 && fireCD <= 0) //火球模式开火
        {
            Fire();
            fireCD = 3;
        }
    }

    void switchMode(int i) //改变模式
    {
        if (i == 1) // firemode
        {
            modeNumber = 1;
            normalmode.SetActive(false);
            firemode.SetActive(true);
            voltmode.SetActive(false);
            icemode.SetActive(false);
        }
        else if (i == 2) // voltmode
        {
            modeNumber = 2;
            normalmode.SetActive(false);
            firemode.SetActive(false);
            voltmode.SetActive(true);
            icemode.SetActive(false);
        }
        else if (i == 3) // icemode
        {
            modeNumber = 3;
            normalmode.SetActive(false);
            firemode.SetActive(false);
            voltmode.SetActive(false);
            icemode.SetActive(true);
        }
    }
    void Fire()
    {
        Debug.Log("fire");
        Instantiate(fireballPrefab, firemode.transform.position, Quaternion.Euler(0, 180, 0), owner);
    }

    void setAnimator(int mode, bool state)
    {
        if (mode == 0) normalmode.GetComponent<Animator>().SetBool("isJumping", state);
        else if (mode == 1) firemode.GetComponent<Animator>().SetBool("isJumping", state);
        else if (mode == 2) voltmode.GetComponent<Animator>().SetBool("isJumping", state);
        else if (mode == 3) icemode.GetComponent<Animator>().SetBool("isJumping", state);
    }
}

