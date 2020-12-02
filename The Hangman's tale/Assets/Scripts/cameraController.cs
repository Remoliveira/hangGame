using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class cameraController : MonoBehaviour
{
    public CinemachineVirtualCamera vc;

    
    public void cameraShake()
    {
        StartCoroutine("Shake");
        //vc = gameObject.GetComponent<CinemachineVirtualCamera>();

    }

    IEnumerator Shake()
    {
        vc.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 3f;
        vc.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = 3f;

        yield return new WaitForSeconds(.3f);

        vc.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0f;
        vc.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = 0f;
    }
}
