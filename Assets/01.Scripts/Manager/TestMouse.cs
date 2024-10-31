using System;
using Manager.MouseWinAPI;
using UnityEngine;

public class TestMouse : MonoBehaviour
{

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            MouseWinAPIManager.SetCursorPosInScreen(10, 10);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            MouseWinAPIManager.SetMouseSpeed(1);
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            MouseWinAPIManager.SetMouseSpeed(20);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            MouseWinAPIManager.ResetMouseSpeed();
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            MouseWinAPIManager.SetBlockInput(true);
        }
        else if (Input.GetKeyDown(KeyCode.H))
        {
            MouseWinAPIManager.SetBlockInput(false);
        }
    }
}