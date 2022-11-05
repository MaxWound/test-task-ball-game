using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    public static GameController instance;

    [SerializeField]
    private float EasySpeed;
    [SerializeField]
    private float MediumSpeed;
    [SerializeField]
    private float HardSpeed;

    private int DifficultyNum;
    private bool GameStarted;

    

    private float Speed;
    private double LastTimerTime;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        
        LastTimerTime = 0;
    }
   public double GetLastTimerTime()
    {
        return LastTimerTime;
    }
    public void SetLastTimerTime(double time)
    {
        LastTimerTime = time;
    }

    //Set
    public void SetEasySpeed()
    {
        Speed = EasySpeed;
        DifficultyNum = 0;

        print("Easy");
    }
    public void SetMediumSpeed()
    {
        Speed = MediumSpeed;
        DifficultyNum = 1;

        print("Medium");

    }
    public void SetHardSpeed()
    {
        Speed = HardSpeed;
        DifficultyNum = 2;

        print("Hard");
    }
    public float GetSpeed()
    {
        return Speed;
    }

    public int GetDifficultyInt()
    {
        return DifficultyNum;
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadPlayLevel()
    {
        GameStarted = true;
        SceneManager.LoadScene(1);
    }
    public bool GetGameStarted()
    { return GameStarted; }
}
