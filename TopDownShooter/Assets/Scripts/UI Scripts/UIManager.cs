using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UIManager;

public class EscapeKeyPressedArgs : EventArgs
{

}
public class TabKeyPressedArgs : EventArgs
{

}

public class UIManager : MonoBehaviour
{
    public delegate void EscapeKeyPressedDelegate(object source, EscapeKeyPressedArgs args);
    public static event EscapeKeyPressedDelegate EscapeKeyPressedEvent;

    public delegate void TabKeyPressedDelegate(object source, TabKeyPressedArgs args);
    public static event TabKeyPressedDelegate TabKeyPressedEvent;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escaped Pressed");
            EscapeKeyPressed();
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Debug.Log("Tab Pressed");
            TabKeyPressed();
        }
    }

    public static void EscapeKeyPressed()
    {
        EscapeKeyPressedEvent?.Invoke(null, new EscapeKeyPressedArgs());
    }

    public static void TabKeyPressed()
    {
        TabKeyPressedEvent?.Invoke(null, new TabKeyPressedArgs());
    }
}
