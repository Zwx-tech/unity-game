using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_display : MonoBehaviour
{
    public Renderer r;

    public void Draw_noise_map(float[,] noise_map)
    {
        int w = noise_map.GetLength(0);
        int h = noise_map.GetLength(1);

        Texture2D texture = new Texture2D(w, h);

        Color[] color_map = new Color[w * h];
        for (int y=0; y<h; y++)
        {
            for (int x = 0; x < w; x++)
            {
                int index = y * w + x;
                color_map[index] = Color.Lerp(Color.black, Color.white, noise_map[x, y]);
            }
        }

        texture.SetPixels(color_map);
        texture.Apply();

        r.sharedMaterial.mainTexture = texture;
        r.transform.localScale = new Vector3(w, 1, h);

    }
}

