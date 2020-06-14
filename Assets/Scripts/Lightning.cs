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
        if (tempTime > 1.75) {
            if (pointLight.intensity == 0) {
                pointLight.intensity = 1;
            } else {
                pointLight.intensity = 0;
            }
            tempTime = 0;
        }
    }
}
