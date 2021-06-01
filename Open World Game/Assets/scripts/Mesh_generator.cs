using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(MeshFilter))]
public class Mesh_generator : MonoBehaviour
{
    //  instancja naszej sitaki
    Mesh mesh;

    // tworzymy listy ktore beda przechowywaly dane o wierzcholkach naszej siatki(mesh)
    // oraz o tym jak powinno sie je laczy w trojkaty
    Vector3[] v;
    int[] triangles;

    // scale

    public int x_size=20;
    public int z_size=20; 
    public float amplitude=2f;

    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh();   
        GetComponent<MeshFilter>().mesh = mesh;

        Create_shape();

        Update_shape();
    }

    
    void Create_shape()
    {
        v = new Vector3[(z_size+1) * (x_size+1)];

        for (int i = 0, z = 0; z <= z_size; z++)
        {
               for (int x = 0; x <= x_size; x++)
               {
                    float y = Mathf.PerlinNoise(x * 0.3f, z * 0.3f) * amplitude;
                    v[i] = new Vector3(x, y, z);
                    i++;
               } 
        }

        int vert=0;
        int tris=0;

        triangles = new int[z_size * x_size * 6];
        for (int  z=0;z<z_size;z++)
        {
            for (int x=0; x<x_size;x++)
                {
                    triangles[tris] = vert;
                    triangles[tris+1] = vert + x_size + 1;
                    triangles[tris+2] = vert + 1;
                    triangles[tris+3] = vert + 1;
                    triangles[tris+4] = vert + x_size + 1;
                    triangles[tris+5] = vert + x_size + 2;
                    vert++;
                    tris+=6;
                }
            vert++;
        }



    }

    void Update_shape()
    {
        // czyscimy siatke
        mesh.Clear();


        // dodajemy nasze wartosci
        mesh.vertices = v;
        mesh.triangles = triangles;


        // naprawa cieni
        mesh.RecalculateNormals();
    }

    void OnDrawGizmos()
    {
        if (v == null)
            return;
        for (int i = 0; i<v.Length; i++)
        {
            Gizmos.DrawSphere(v[i], 0.1f);
        }
    }
}
