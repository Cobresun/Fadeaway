using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

// Manages the lighting of an entire screen.
public class GlobalIllumination : MonoBehaviour
{
    private static float brightness;
    
    private static float intensity;
    private static float baseIntensity;
    private static float maxIntensity;

    public Light2D globalLight; 

    // Start is called before the first frame update
    void Start()
    {
        baseIntensity = 0.3f;
        maxIntensity = 0.6f;
        intensity = baseIntensity;
        brightness = 0;
        globalLight.intensity = baseIntensity;
    }

    // Update is called once per frame
    void Update()
    {
        globalLight.intensity = intensity;
    }

    public static void updateBrightnessBy(float percentBrightness) {
        if (brightness + percentBrightness >= 1) {
            brightness = 1;
        }
        else if (brightness + percentBrightness <= 0) {
            brightness = 0;
        }
        else {
            brightness += percentBrightness;
        }
        intensity = brightness * (maxIntensity - baseIntensity) + baseIntensity;
    }

    public static float getBrightness() {
        return brightness;
    }

    public static bool unlit() {
        return brightness == 0;
    }
}

