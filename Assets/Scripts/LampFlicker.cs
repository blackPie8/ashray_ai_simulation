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
        bulbMaterial = bulbRenderer.material;   // reference of original material

        flickerOffset = Random.Range(0f, 100f);  // random generation for random flicker
    }

    void Update()
    {
        // takes two argument x and y returns val in b/w, does not jump abruptly to the next; slowly increses on its way
        float noise = Mathf.PerlinNoise((Time.time + flickerOffset) / flickerSpeed, 0f);
        // maps the intensity b/w min and max based on noise
        float intensity = Mathf.Lerp(minIntensity, maxIntensity, noise);

        pointLight.intensity = intensity;


        if (bulbMaterial != null)
        {
            // multiplied both to control the intensity of the material
            Color finalColor = emissionColor * intensity;
            bulbMaterial.SetColor("_EmissionColor", finalColor);

            // Built-in RP
            DynamicGI.SetEmissive(bulbRenderer, finalColor);
        }
    }
}
