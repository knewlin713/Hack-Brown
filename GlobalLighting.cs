using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GlobalLighting : MonoBehaviour
{
    public static Light2D light;

    private void Start()
    {
        light = GetComponent<Light2D>();
    }

    public static void Increase()
    {
        light.intensity = light.intensity + 0.1f;
    }

}
