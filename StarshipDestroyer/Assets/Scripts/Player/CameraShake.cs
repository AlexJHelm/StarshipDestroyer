using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class CameraShake : MonoBehaviour
{
    private CinemachineVirtualCamera CinemachineVirtualCamera;
    private float Shakeintensity = 1f;
    public float ShakeTime = 0.2f;
    public bool cameraShaking, shakeStarted = false;

    private float timer;
    private CinemachineBasicMultiChannelPerlin _cbmcp;


    void Awake()
    {
        CinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    private void Start()
    {
        StopShake();
    }

    public void ShakeCamera()
    {
        CinemachineBasicMultiChannelPerlin _cbmcp = CinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _cbmcp.m_AmplitudeGain = Shakeintensity;

        timer = ShakeTime;
    }

    void StopShake()
    {
        CinemachineBasicMultiChannelPerlin _cbmcp = CinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _cbmcp.m_AmplitudeGain = 0f;
        timer = 0;
    }
    void Update()
    {
        if (cameraShaking == true)
        {
            if(shakeStarted == false)
            {
                ShakeCamera();
                shakeStarted = true;
            }
            
        }

        if (timer > 0)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                StopShake();
                cameraShaking = false;
                shakeStarted = false;
            }
        }
    }

}
