using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class PlayLevelUI : MonoBehaviour
{
    
    Canvas canvas;
    private void Start()
    {
        canvas = GetComponent<Canvas>();
        gameObject.SetActive(false);
    }
    public void ShowUI()
    {
        gameObject.SetActive(true);
    }
    public void ToMenu()
    {
        GameController.instance.LoadMenu();
    }
    public void Restart()
    {
        GameController.instance.LoadPlayLevel();

    }
    
}
