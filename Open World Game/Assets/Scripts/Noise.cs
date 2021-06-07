using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Noise
{
    public static float[,] Genrate_noise(int map_w, int map_h, float scale)
    {
        float[,] noise_map = new float[map_w, map_h];

        if (scale <= 0)
        {
            scale = 0.001f;
        }
        for (int z = 0; z < map_h;z++)
        {
            for (int x = 0; x < map_w; x++)
            {
                float sample_z = z / scale;
                float sample_x = x / scale;

                float perlin_value = Mathf.PerlinNoise(sample_x, sample_z);

                noise_map[x, z] = perlin_value;
            }
        }

        return noise_map;
    }
}
