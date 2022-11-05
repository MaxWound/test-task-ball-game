using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    [SerializeField]
    TMP_Text TriesCountText;
    [SerializeField]
    TMP_Text lastTimeText;
    [SerializeField]
    Button EasyButton;
    [SerializeField]
    Button MediumButton;
    [SerializeField]
    Button HardButton;
    private bool GameStarted;
    private bool SpeedChoosed;
    public void SetLastTimeText()
    {
        lastTimeText.text = $"Последнее время: {GameController.instance.GetLastTimerTime().ToString()}";
    }
    public void SetEasy()
    {
        GameController.instance.SetEasySpeed();
        SpeedChoosed = true;
    }
    public void SetMedium()
    {
        GameController.instance.SetMediumSpeed();
        SpeedChoosed = true;
    }
    public void SetHard()
    {
        GameController.instance.SetHardSpeed();
        SpeedChoosed = true;
    }
    private void Start()
    {
        if(PlayerPrefs.GetInt("TriesCount") != null)
        {
            TriesCountText.text = $"Количество попыток: {PlayerPrefs.GetInt("TriesCount")}";
        }
        else
        {
            TriesCountText.text = "Количество попыток: 0";
        }
        SetLastTimeText();
        if (GameController.instance.GetGameStarted() == true)
        {
            CheckButton();
        }
        GameStarted = true;
    }
    public void CheckButton()
    {

        int difficultyNum = GameController.instance.GetDifficultyInt();
            if (difficultyNum == 0)
        {
            SetEasy();
            EasyButton.Select();
        }
            else if(difficultyNum == 1)
        {
            SetMedium();
            MediumButton.Select();
        }
            else if(difficultyNum == 2)
        {
            SetHard();
            HardButton.Select();
        }
    }

    public void Play()
    {
        if (SpeedChoosed)
        {
            GameController.instance.LoadPlayLevel();
        }

    }
}
