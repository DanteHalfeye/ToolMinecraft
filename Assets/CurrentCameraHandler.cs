using System;
using Unity.Cinemachine;
using UnityEngine;

public class CurrentCameraHandler : MonoBehaviour
{
    public static CurrentCameraHandler Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public CinemachineCamera cameraTop;
    public CinemachineCamera cameraBottom;
    public CinemachineCamera cameraLeft;
    public CinemachineCamera cameraRight;
    public CinemachineCamera cameraFront;
    public CinemachineCamera cameraBack;
    public CinemachineCamera currentCamera;

    private void Update()
    {
        currentCamera = GetHighestPriorityCamera();
    }

    private CinemachineCamera GetHighestPriorityCamera()
    {
        CinemachineCamera[] cameras = { cameraTop, cameraBottom, cameraLeft, cameraRight, cameraFront, cameraBack };
        CinemachineCamera highestPriorityCamera = cameras[0];

        foreach (var cam in cameras)
        {
            if (cam.Priority > highestPriorityCamera.Priority)
            {
                highestPriorityCamera = cam;
            }
        }

        return highestPriorityCamera;

        CinemachineCamera CheckPriority(CinemachineCamera camera1, CinemachineCamera camera2)
        {
            if (camera1.Priority > camera2.Priority)
            {
                return camera1;
            }
            else
            {
                return camera2;
            }
        }

    }
}
