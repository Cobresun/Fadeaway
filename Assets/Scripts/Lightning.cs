using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Lightning : MonoBehaviour
{

    public Light2D pointLight; 
    float tempTime;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        tempTime += Time.deltaTime;
        if (pointLight.intensity == 0) {
            if (tempTime > 0.8) {
                pointLight.intensity = 1;
                tempTime = 0;
            }
        }
        else {
            if (tempTime > 1.8) {
                pointLight.intensity = 0;
                tempTime = 0;
            }
        }
    }
}
