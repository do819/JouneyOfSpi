using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public void PlayGame()
    {
        Application.LoadLevel("LevelMenu");
    }

    public void Exit()
    {
        Application.Quit();
    }
}