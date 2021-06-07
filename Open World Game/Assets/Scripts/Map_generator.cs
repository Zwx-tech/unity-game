using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_generator : MonoBehaviour
{
    public int w=20;
    public int h=20;
    public float scale=1;
    public bool auto_update;

    public void Generate_map()
    {
        float[,] noise = Noise.Genrate_noise(w, h, scale);

        Map_display display = FindObjectOfType<Map_display>();
        display.Draw_noise_map(noise);
    }
}
