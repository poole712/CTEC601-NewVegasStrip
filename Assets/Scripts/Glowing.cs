using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glowing : MonoBehaviour
{
    public Material material;
    private float glowValue;
    private bool increasing = true;

    public Color baseColor = Color.white; // Base color for emission
    public float glowStrength = 1.0f; // Maximum emission strength
    public float glowSpeed = 1.0f; // Speed of the glow effect

    // Start is called before the first frame update
    void Start()
    {
    }


    void Update()
    {
        // Calculate the new glow value
        if (increasing)
        {
            glowValue += Time.deltaTime * glowSpeed;
            if (glowValue >= glowStrength)
            {
                glowValue = glowStrength;
                increasing = false;
            }
        }
        else
        {
            glowValue -= Time.deltaTime * glowSpeed;
            if (glowValue <= 0.5f)
            {
                glowValue = 0.5f;
                increasing = true;
            }
        }

        // Set the emission color
        Color emissionColor = baseColor * Mathf.LinearToGammaSpace(glowValue);
        material.SetColor("_EmissionColor", emissionColor);

        // Update the global emission property
        DynamicGI.SetEmissive(GetComponent<Renderer>(), emissionColor);
    }
}

