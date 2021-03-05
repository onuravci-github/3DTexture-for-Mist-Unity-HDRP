using UnityEditor;
using UnityEngine;

public class Create3DTexture : MonoBehaviour
{
    [MenuItem("Create3DTexture/3DTexture")]
    static void CreateTexture3D()
    {
        // Configure the texture
        int size = 32;
        float transparentvalue = 0.05f;
        TextureFormat format = TextureFormat.Alpha8;
        TextureWrapMode wrapMode =  TextureWrapMode.Clamp;

        // Create the texture and apply the configuration
        Texture3D texture = new Texture3D(size, size, size, format, false);
        texture.wrapMode = wrapMode;

        // Create a 3-dimensional array to store color data
        Color[] colors = new Color[size * size * size];
        for(int i = 0; i < size*size*size ; i++)
        {
            colors[i] = new Color(0,0,0,Random.Range(0,transparentvalue));
        }

        // Copy the color values to the texture
        texture.SetPixels(colors);

        // Apply the changes to the texture and upload the updated texture to the GPU
        texture.Apply();        

        // Save the texture to your Unity Project
        AssetDatabase.CreateAsset(texture, "Assets/Creaps 3d Texture.asset");
    }
}