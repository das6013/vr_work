using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTest1 : MonoBehaviour
{
    public Transform obj1;
    float distance;
    public Light light;
   

    float LightIntensity(Light light, float distance)
    {
        return light.intensity * (1f - Mathf.Clamp01(distance / light.range));
    }
    // Update is called once per frame

    void Update()
    {
        
       distance = Vector3.Distance(light.transform.position, obj1.position);
            Debug.Log(LightIntensity(light, distance));
       
    }
}
