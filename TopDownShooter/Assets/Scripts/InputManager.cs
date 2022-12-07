using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMouseLeftArgs : EventArgs
{
}
public class InputWArgs : EventArgs
{
}
public class InputAArgs : EventArgs
{
}
public class InputSArgs : EventArgs
{
}
public class InputDArgs : EventArgs
{
}
public class InputTabArgs : EventArgs
{
}
public class InputEscapeArgs : EventArgs
{
}

public class InputManager : MonoBehaviour
{
    public delegate void InputMouseLeftDelegate(object source, InputMouseLeftArgs args);
    public static event InputMouseLeftDelegate InputMouseLeftEvent;

    public delegate void InputWDelegate(object source, InputWArgs args);
    public static event InputWDelegate InputWEvent;

    public delegate void InputADelegate(object source, InputAArgs args);
    public static event InputADelegate InputAEvent;

    public delegate void InputSDelegate(object source, InputSArgs args);
    public static event InputSDelegate InputSEvent;

    public delegate void InputDDelegate(object source, InputDArgs args);
    public static event InputDDelegate InputDEvent;

    public delegate void InputTabDelegate(object source, InputTabArgs args);
    public static event InputTabDelegate InputTabEvent;

    public delegate void InputEscapeDelegate(object source, InputEscapeArgs args);
    public static event InputEscapeDelegate InputEscapeEvent;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            InputMouseLeft();
        }
        if (Input.GetKey(KeyCode.W))
        {
            InputW();
        }
        if (Input.GetKey(KeyCode.A))
        {
            InputA();
        }
        if (Input.GetKey(KeyCode.S))
        {
            InputS();
        }
        if (Input.GetKey(KeyCode.D))
        {
            InputD();
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            InputTab();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            InputEscape();
        }
    }

    private static void InputMouseLeft()
    {
        InputMouseLeftEvent?.Invoke(null, new InputMouseLeftArgs() {});
    }
    private static void InputW()
    {
        InputWEvent?.Invoke(null, new InputWArgs() { });
    }
    private static void InputA()
    {
        InputAEvent?.Invoke(null, new InputAArgs() { });
    }
    private static void InputS()
    {
        InputSEvent?.Invoke(null, new InputSArgs() { });
    }
    private static void InputD()
    {
        InputDEvent?.Invoke(null, new InputDArgs() { });
    }
    private static void InputTab()
    {
        InputTabEvent?.Invoke(null, new InputTabArgs() { });
    }
    private static void InputEscape()
    {
        InputEscapeEvent?.Invoke(null, new InputEscapeArgs() { });
    }
}
