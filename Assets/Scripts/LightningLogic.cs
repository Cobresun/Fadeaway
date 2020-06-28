using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;

public class LightningLogic : MonoBehaviour
{
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
            GlobalIllumination.updateBrightnessBy(100);
            timeSinceFlash = 0;
            nextFlash = Random.Range(1.0f, 2.5f);
        }

        if (GlobalIllumination.getBrightness() <= 70 && GlobalIllumination.getBrightness() > 40)
        {
            flashBuildUp += Time.deltaTime * Random.Range(0.07f, 0.02f);
        }

        if (flashBuildUp >= Random.Range(1.0f, 1.1f))
        {
            Debug.Log("Second Flash");
            GlobalIllumination.updateBrightnessBy(Random.Range(20, 40));
            flashBuildUp = 0f;
        }
    }

    // Fixed fade in light
    void FixedUpdate()
    {
        if (GlobalIllumination.unlit())
        {
            GlobalIllumination.updateBrightnessBy(-9);                  // TODO: instead of 0.8f all the time, attach this to a variable based on difficulty
            if (GlobalIllumination.getBrightness() <= 30)
            {
                GlobalIllumination.updateBrightnessBy(-3);
            }
            
        }
    }
}
