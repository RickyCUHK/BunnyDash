using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Status : MonoBehaviour
{
    static public int health;
    static public int point;
    static public int killNumber;
    static public float gameTime;
    public Text score;
    public GameObject GameoverUI;
    public GameObject overAudio;

    static public int modeNumber;
    static public int fireCount;
    static public int iceCount;
    static public int voltCount;
    
    // Start is called before the first frame update
    void Start()
    {
        gameTime = 0;
        health = 3;
        modeNumber = 0;
        killNumber = 0;
        fireCount = 0;
        iceCount = 0;
        voltCount = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        gameTime += Time.deltaTime;
        point = 10 * killNumber + Mathf.FloorToInt(gameTime);
        CheckMode();
        CheckHealth();
        score.text = point.ToString();
    }

    void CheckMode()
    {
        if (fireCount >= 3) modeNumber = 1;
        if (voltCount >= 3) modeNumber = 2;
        if (iceCount >= 3) modeNumber = 3;
    }

    void CheckHealth()
    {
        if (health <= 0)
        {
            Debug.Log("GAME OVER");
            Destroy(gameObject);
            GameoverUI.SetActive(true);
            overAudio.GetComponent<AudioSource>().Play();
            Camera.main.GetComponent<AudioSource>().Stop();
        }
    }
}
