using System.Collections;
using System.Collections.Generic;
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
        nextFlash = Random.Range(1, 3);
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceFlash += Time.deltaTime;

        if (pointLight.intensity >= 0) {
            pointLight.intensity -= 0.002f;
            if (pointLight.intensity <= 0.6f) {
                pointLight.intensity -= 0.001f;
            }
            else if (pointLight.intensity <= 1){
                flashBuildUp += Time.deltaTime*Random.Range(0.07f, 0.02f);
            }

            if (flashBuildUp >= Random.Range(1.0f, 1.1f)){
                pointLight.intensity += Random.Range(0.3f, 0.6f);
            }
        }

        if (timeSinceFlash >= nextFlash) {
            pointLight.intensity = 1.5f;
            timeSinceFlash = 0;
            nextFlash = Random.Range(1.5f, 3.0f);
        }
    }
}
