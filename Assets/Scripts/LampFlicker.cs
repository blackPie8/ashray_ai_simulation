using UnityEngine;

public class LampFlicker : MonoBehaviour
{
    [Header("Light Settings")]
    public Light pointLight;
    public float minIntensity = 1.5f;
    public float maxIntensity = 3f;
    public float flickerSpeed = 0.1f;

    [Header("Bulb Material Settings")]
    public Renderer bulbRenderer;
    private Color emissionColor = Color.aquamarine;
    private Material bulbMaterial;


    private float flickerOffset;


    void Start()
    {
        bulbMaterial = bulbRenderer.material;

        flickerOffset = Random.Range(0f, 100f);
    }

    void Update()
    {
        float noise = Mathf.PerlinNoise((Time.time + flickerOffset) / flickerSpeed, 0f);
        float intensity = Mathf.Lerp(minIntensity, maxIntensity, noise);

        pointLight.intensity = intensity;


        if (bulbMaterial != null)
        {
            Color finalColor = emissionColor * intensity;
            bulbMaterial.SetColor("_EmissionColor", finalColor);

            // Built-in RP needs this to update emission in scene
            DynamicGI.SetEmissive(bulbRenderer, finalColor);
        }
    }
}
