using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(MeshFilter))]
public class MeshGenerator : MonoBehaviour
{

    Mesh mesh;

 

    private MeshCollider meshCollider;
    Vector3[] vertices;
    int[] triangles;
    Color[] colors;
    public int xSize = 20;
    public int zSize = 20;
    public float curve=0;
    public Gradient gradient;

    float minTerrainHeight;
    float maxTerrainHeight;
    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        meshCollider = GetComponent<MeshCollider>();
        
        CreateShape();
        UpdateMesh();
        
    }
    void CreateShape()
    {
        vertices = new Vector3[(xSize + 1) * (zSize + 1)];

       

        for (int i=0, z=0; z <= zSize; z++)
        {
            curve=0;
            for (int x=0; x<=xSize; x++)
            {
                curve=4*(Mathf.Pow((x-50f),0.4f));
                float y = Mathf.PerlinNoise(x*.1f, z*.1f) * 0.9f;
                if (x>80){
                    y+=curve-15.5f;
                }
                vertices[i] = new Vector3(x, y, z);

                if (y > maxTerrainHeight)
                {
                    maxTerrainHeight = y;
                }
                if (y < minTerrainHeight)
                {
                    minTerrainHeight = y;
                }
                i++;
            }
        }
        triangles = new int[xSize*zSize*6];
        int vert = 0;
        int tris = 0;
        for (int z = 0; z < zSize; z++)
        {
            for (int x = 0; x < xSize; x++)
            {

                triangles[tris + 0] = vert + 0;
                triangles[tris + 1] = vert + xSize + 1;
                triangles[tris + 2] = vert + 1;
                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + xSize + 1;
                triangles[tris + 5] = vert + xSize + 2;
                vert++;
                tris += 6;
            }
            vert++;

        }

        colors = new Color[vertices.Length];
        for (int i = 0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                float height = Mathf.InverseLerp(minTerrainHeight, maxTerrainHeight, vertices[i].y);
                colors[i] = gradient.Evaluate(height);
                i++;
            }
        }


    }

    void UpdateMesh()
    {
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.colors = colors;
     
        mesh.RecalculateNormals();
        meshCollider.sharedMesh = mesh;
    }

     void FixedUpdate()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
