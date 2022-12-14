using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    bool isPaused;

    void Start()
    {
        isPaused = false;
        this.gameObject.SetActive(false);
        InputManager.InputEscapeEvent += PauseGameMenu;
    }
    
    private void PauseGameMenu(object source, InputEscapeArgs args)
    {
        if(isPaused == false)
        {
            this.gameObject.SetActive(true);
            isPaused = true;
        }
        else
        {
            this.gameObject.SetActive(false);
            isPaused = false;
        }
    }
}
