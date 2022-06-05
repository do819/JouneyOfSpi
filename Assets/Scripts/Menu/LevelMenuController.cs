using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMenuController : MonoBehaviour
{
    public void Back()
    {
        Application.LoadLevel("MainMenu");
    }
}
