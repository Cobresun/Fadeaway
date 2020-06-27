using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Lightning : MonoBehaviour
{

    public Light2D pointLight; 
    float timeSinceFlash = 0;
    float nextFlash;
    float flashBuildUp = 0;

    // Start is called before the first frame update
    void Start()
    {
        nextFlash = Random.Range(1.5f, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceFlash += Time.deltaTime;

        if (timeSinceFlash >= nextFlash) {
            Debug.Log("Flash");
            pointLight.intensity = 1.5f;
            timeSinceFlash = 0;
            nextFlash = Random.Range(1.0f, 2.5f);
        }

        if (pointLight.intensity <= 1.0f && pointLight.intensity > 0.6f)
        {
            flashBuildUp += Time.deltaTime * Random.Range(0.07f, 0.02f);
        }

        if (flashBuildUp >= Random.Range(1.0f, 1.1f))
        {
            Debug.Log("Second Flash");
            pointLight.intensity += Random.Range(0.3f, 0.6f);
            flashBuildUp = 0f;
        }
    }

    void FixedUpdate()
    {
        if (pointLight.intensity >= 0)
        {
            pointLight.intensity -= Time.deltaTime * 1.9f;                  // TODO: instead of 0.8f all the time, attach this to a variable based on difficulty
            if (pointLight.intensity <= 0.3f)
            {
                pointLight.intensity -= Time.deltaTime * 0.1f;
            }
            
        }
    }
}
