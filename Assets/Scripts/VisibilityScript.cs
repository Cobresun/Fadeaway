using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibilityScript : MonoBehaviour
{
    SpriteRenderer m_SpriteRenderer;

    void Start()
    {
        //Fetch the SpriteRenderer from the GameObject
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        m_SpriteRenderer.color = new Color(1f,1f,1f,GlobalIllumination.getBrightness());
    }
}
