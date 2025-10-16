using UnityEngine;
using System;
public class EmissionController : MonoBehaviour
{
    public Renderer targetRenderer;

    [ColorUsage(true, true)]
    public Color hdrLight = new Color(7.135f, 3.21f, 2.425f, 1f) * 3.25f;

    [ColorUsage(true, true)]
    public Color hdrDark = new Color(0f, 0.053f, 0.2f, 1f) * 0f;

    public DistanceChecker distanceChecker;
    void Start()
    {
    
        Material mat = targetRenderer.material;

        // Update the shader's emission color
        mat.SetColor("_EmissionColor", hdrDark);
    }


    void Update()
    {
        float d = distanceChecker.Distance;
        float colorf = 0.0f;
        float startDistance = 6.5f;
        if (d < startDistance)
        {
            float exp = -(((10 * d) / startDistance) - 5);
            float denom = 1 + (float)(Math.Pow(Math.E, exp));
            colorf = 1 / denom;
        }
        else
        {
            colorf = 1f;
        }
        //Color hdrRed = new Color(1f, 0f, 0f, 1f) * 5f;   // bright red (intensity 5)
        //Color hdrBlue = new Color(0f, 0f, 1f, 1f) * 3f;  // bright blue (intensity 3)
        Color dynamicColor = Color.Lerp(hdrLight, hdrDark, colorf);
        targetRenderer.material.SetColor("_EmissionColor", dynamicColor);
    }
}

