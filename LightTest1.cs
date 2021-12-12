using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTest1 : MonoBehaviour
{
    float distance;
    public Light light;


    float LightIntensity(Light light, float distance)
    {
       
        return light.intensity * (1f - Mathf.Clamp01(distance / light.range));
    }
    // Update is called once per frame
   
    void Update()
    {
 
       distance = Vector3.Distance(light.transform.position, transform.position);

       RaycastHit hit;
       Ray ray = new Ray(transform.position, light.transform.position - transform.position);
        Physics.Raycast(ray, out hit);
        Debug.Log(hit.collider);
        if (hit.collider.name == "sun")
            Debug.Log(LightIntensity(light, distance));
        else Debug.Log(0);






    }
}
