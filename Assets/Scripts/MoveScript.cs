using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoveScript : MonoBehaviour
{
    [SerializeField]
    TMP_Text timerText;

    [SerializeField]
    PlayLevelUI _playLevelUI;
    
    private float horSpeed;
    [SerializeField]
    private float verSpeed;

    [SerializeField]
    private float speedTimer;

    private float speedTimerTime;

    private bool ToMove = true;

    [SerializeField]
    private float timerTime;

    Rigidbody2D rb;
    private void Start()
    {
        if (PlayerPrefs.GetInt("TriesCount") != null)
        {
            PlayerPrefs.SetInt("TriesCount", PlayerPrefs.GetInt("TriesCount") + 1);
            PlayerPrefs.Save();
        }
        else
        {
            PlayerPrefs.SetInt("TriesCount", 1);
            PlayerPrefs.Save();
        }
        rb = GetComponent<Rigidbody2D>();
        speedTimerTime = speedTimer;
        horSpeed = GameController.instance.GetSpeed();
    }
    private void Update()
    {

        // rb.position = rb.position + new Vector2(Time.deltaTime * 3, 0f);
        if (ToMove)
        {
            timerTime += Time.deltaTime;
            timerText.text =  $"Βπεμÿ: {System.Math.Round(timerTime, 1).ToString()}";
            transform.position = transform.position + new Vector3(Time.deltaTime * horSpeed, 0f, 0f);
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.position = transform.position + new Vector3(0, Time.deltaTime * verSpeed, 0f);
            }
            else
            {
                transform.position = transform.position + new Vector3(0, Time.deltaTime * -verSpeed, 0f);
            }
            speedTimerTime -= Time.deltaTime;
            if (speedTimerTime <= 0)
            {
                print("time");
                speedTimerTime = speedTimer;
                verSpeed += 1f;
            }
        }
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        TileSpawner.instance.Spawn();
        print("υσι");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        ToMove = false;
        rb.simulated = false;
        horSpeed = 0;
        verSpeed = 0;
        _playLevelUI.ShowUI();
        GameController.instance.SetLastTimerTime(System.Math.Round(timerTime, 1));
    }

}
