using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Noise
{
    public static float[,] Genrate_noise(int z_size, int x_size, float scale)
    {
        float[,] noise_map = new float[x_size, z_size];

        if (scale <= 0)
        {
            scale = 0.001f;
        }
        for (int z = 0; z < z_size;z++)
        {
            for (int x = 0; x < x_size; x++)
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
