using System.Collections;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.Rendering.Universal;

public class RoomLightController : MonoBehaviour
{
    public Light2D roomLight; 
    public float lightIncreaseSpeed = 0.1f; 
    private bool isIlluminating = false;

    void Update()
    {
        if (isIlluminating && roomLight.intensity < 1)
        {
            roomLight.intensity += lightIncreaseSpeed * Time.deltaTime;
        }
    }

    public void StartIllumination()
    {
        isIlluminating = true;
    }
}


