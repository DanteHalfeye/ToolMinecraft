using System;
using UnityEngine;
using XCharts.Runtime;

public class UiManager : MonoBehaviour
{
    CurrentCameraHandler handler;
    private void Awake()
    {
        handler = CurrentCameraHandler.Instance;
    }

    public void RightButton()
    {
        handler.currentCamera.Priority = 0;
        if (handler.currentCamera == handler.cameraFront)
        {
            handler.cameraRight.Priority = 1;
            return;
        }

        if (handler.currentCamera == handler.cameraRight)
        {
            handler.cameraBack.Priority = 1;
            return;
        }
        if (handler.currentCamera == handler.cameraBack)
        {
            handler.cameraLeft.Priority = 1;
            return;
        }

        if (handler.currentCamera == handler.cameraLeft)
        {
            handler.cameraFront.Priority = 1;
        }
        if (handler.currentCamera == handler.cameraTop)
        {
            handler.cameraRight.Priority = 1;
            return;
        }
        if (handler.currentCamera == handler.cameraBottom)
        {
            handler.cameraLeft.Priority = 1;
            return;
        }
    }
    public void LeftButton()
    {
        handler.currentCamera.Priority = 0;
        if (handler.currentCamera == handler.cameraFront)
        {
            handler.cameraLeft.Priority = 1;
            return;
        }

        if (handler.currentCamera == handler.cameraRight)
        {
            handler.cameraFront.Priority = 1;
            return;
        }
        if (handler.currentCamera == handler.cameraBack)
        {
            handler.cameraRight.Priority = 1;
            return;
        }

        if (handler.currentCamera == handler.cameraLeft)
        {
            handler.cameraBack.Priority = 1;
        }
        if (handler.currentCamera == handler.cameraTop)
        {
            handler.cameraLeft.Priority = 1;
            return;
        }
        if (handler.currentCamera == handler.cameraBottom)
        {
            handler.cameraRight.Priority = 1;
            return;
        }
    }
    public void TopButton()
    {
        handler.currentCamera.Priority = 0;
        if (handler.currentCamera == handler.cameraFront)
        {
            handler.cameraTop.Priority = 1;
            return;
        }

        if (handler.currentCamera == handler.cameraRight)
        {
            handler.cameraTop.Priority = 1;
            return;
        }
        if (handler.currentCamera == handler.cameraBack)
        {
            handler.cameraTop.Priority = 1;
            return;
        }

        if (handler.currentCamera == handler.cameraLeft)
        {
            handler.cameraTop.Priority = 1;
        }
        if (handler.currentCamera == handler.cameraTop)
        {
            handler.cameraBack.Priority = 1;
            return;
        }
        if (handler.currentCamera == handler.cameraBottom)
        {
            handler.cameraFront.Priority = 1;
            return;
        }
    }
    public void BottomButton()
    {
        handler.currentCamera.Priority = 0;
        if (handler.currentCamera == handler.cameraFront)
        {
            handler.cameraBottom.Priority = 1;
            return;
        }

        if (handler.currentCamera == handler.cameraRight)
        {
            handler.cameraBottom.Priority = 1;
            return;
        }
        if (handler.currentCamera == handler.cameraBack)
        {
            handler.cameraBottom.Priority = 1;
            return;
        }

        if (handler.currentCamera == handler.cameraLeft)
        {
            handler.cameraBottom.Priority = 1;
        }
        if (handler.currentCamera == handler.cameraTop)
        {
            handler.cameraFront.Priority = 1;
            return;
        }
        if (handler.currentCamera == handler.cameraBottom)
        {
            handler.cameraBack.Priority = 1;
            return;
        }
    }
}
