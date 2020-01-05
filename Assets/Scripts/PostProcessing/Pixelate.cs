using UnityEngine;

[ExecuteInEditMode, RequireComponent(typeof(Camera))]
public class Pixelate : MonoBehaviour {
    public Material material;
    public int pixelDensity = 256;

    private void OnRenderImage(RenderTexture source, RenderTexture destination) {
        Vector2 aspectRatioData;
        aspectRatioData = new Vector2((float)Screen.width / Screen.height, 1);
        material.SetVector("_AspectRatioMultiplier", aspectRatioData);
        material.SetInt("_PixelDensity", pixelDensity);
        Graphics.Blit(source, destination, material);
    }
}
