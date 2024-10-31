using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Manager.MouseWinAPI
{
    public static class MouseWinAPIManager
    {
        private const uint SPI_SETMOUSESPEED = 0x0071;
        private const uint SPI_GETMOUSESPEED = 0x0070;
        private const uint SPI_SETMOUSECLICKLOCK = 0x101F;
        
        private static int _defaultMouseSpeed;
    
        [DllImport("user32.dll")]
        private static extern bool SystemParametersInfo(uint uiAction, uint uiParam, IntPtr pvParam, uint fWinIni);
        
        [DllImport("user32.dll")]
        private static extern bool SystemParametersInfo(uint uiAction, uint uiParam, ref int pvParam, uint fWinIni);
        
        [DllImport("user32.dll")]
        private static extern bool SetCursorPos(int X, int Y);
    
        /// <summary>
        /// 마우스 고정
        /// </summary>
        public static void SetCursorPosInScreen(int X, int Y)
        {
            SetCursorPos(X, Y);
        }

        /// <summary>
        /// 마우스 스피드 설정
        /// </summary>
        /// <param name="speed">마우스 속도</param>
        public static void SetMouseSpeed(int speed)
        {
            if (_defaultMouseSpeed == 0)
            {
                _defaultMouseSpeed = GetMouseSpeed();
            }
            SystemParametersInfo(SPI_SETMOUSESPEED, 0, (IntPtr) speed, 0);
        }
        
        public static int GetMouseSpeed()
        {
            int speed = 10;
            SystemParametersInfo(SPI_GETMOUSESPEED, 0, ref speed, 0);
            return speed;
        }
        
        public static void ResetMouseSpeed()
        {
            SystemParametersInfo(SPI_SETMOUSESPEED, 0, (IntPtr) _defaultMouseSpeed, 0);
        }
    
        /// <summary>
        /// 마우스 입력 차단 여부
        /// </summary>
        /// <param name="isBlock">차단할지 여부</param>
        public static void SetBlockInput(bool isBlock)
        {
            SystemParametersInfo(SPI_SETMOUSECLICKLOCK, 0, ref isBlock, 0);
        }
    }
}
