using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

// Manages the lighting of an entire screen.
public class GlobalIllumination : MonoBehaviour
{
    private static int brightness;
    
    private static float intensity;
    private static float baseIntensity;
    private static float maxIntensity;

    public Light2D globalLight; 

    // Start is called before the first frame update
    void Start()
    {
        baseIntensity = 0.2f;
        maxIntensity = 0.7f;
        intensity = baseIntensity;
        brightness = 0;
        globalLight.intensity = baseIntensity;
    }

    // Update is called once per frame
    void Update()
    {
        globalLight.intensity = intensity;
    }

    public static void updateBrightnessBy(int percentBrightness) {
        if (brightness + percentBrightness >= 100) {
            brightness = 100;
        }
        else if (brightness + percentBrightness <= 0) {
            brightness = 0;
        }
        else {
            brightness += percentBrightness;
        }

        intensity = brightness / 100 * (maxIntensity - baseIntensity);
    }

    public static int getBrightness() {
        return brightness;
    }

    public static bool unlit() {
        return brightness == 0;
    }
}

