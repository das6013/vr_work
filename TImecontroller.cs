using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TImecontroller : MonoBehaviour
{
    [SerializeField] private Light sun;
    [SerializeField] private float secondsInFillDay = 120f;
    private float corX;
    [Range(0, 1)] [SerializeField] private float currentTimefoDay = 0;
    private float timeMultiplier = 1f;
    private float sunInitialIntensity;
    private void Start()
    {
        sunInitialIntensity = sun.intensity;
    }
    private void Update()
    {
        UpdateSun();
        currentTimefoDay += (Time.deltaTime / secondsInFillDay) * timeMultiplier;
        if (currentTimefoDay >= 1) 
        {
            currentTimefoDay = 0;
        }

    }
    void UpdateSun()
    {
        sun.transform.localRotation = Quaternion.Euler((currentTimefoDay * 360f) - 90, 170, 0);
        float intensityMultiplier = 1;
        if (currentTimefoDay <= 0.23f || currentTimefoDay >= 0.75f)
        {
            intensityMultiplier = 0;
        }
        else if (currentTimefoDay <= 0.25f)
        {
            intensityMultiplier=Mathf.Clamp01((currentTimefoDay-0.23f)*(1/0.02f));
        }
        else if (currentTimefoDay >= 0.73f)
        {
            intensityMultiplier = Mathf.Clamp01(1-(currentTimefoDay - 0.73f) * (1 / 0.02f));
        }
        sunInitialIntensity = sunInitialIntensity * intensityMultiplier;
    }

}
