using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlacementGenerator : MonoBehaviour
{
    [SerializeField] GameObject prefab;

    [Header("Raycast Settings")]
    [SerializeField] int density;

    [Space]

    [SerializeField] float minHeight;
    [SerializeField] float maxHeight;
    [SerializeField] Vector2 xRange;
    [SerializeField] Vector2 zRange;

    [Header("Pregab Variation Settings")]
    [SerializeField, Range(0, 1)] float rotateTowardsNormal;
    [SerializeField] Vector2 rotationRange;
    [SerializeField] Vector3 minScale;
    [SerializeField] Vector3 maxScale;

    public void Generate()
    {
        
        Clear();
        
        for (int i=0; i<density; i++)
        {
            
            float sampleX = Random.Range(xRange.x, xRange.y);
            float sampleY = Random.Range(zRange.x, zRange.y);

            Vector3 rayStart = new Vector3(sampleX, maxHeight, sampleY);

            if (!Physics.Raycast(rayStart, Vector3.down, out RaycastHit hit, Mathf.Infinity))
            {
                continue;
            }

          
            if (hit.collider.tag=="Floor"){      
            GameObject instantiatePrefab = (GameObject)PrefabUtility.InstantiatePrefab(this.prefab, transform);
            instantiatePrefab.transform.position = hit.point;
            instantiatePrefab.transform.Rotate(Vector3.up, Random.Range(rotationRange.x, rotationRange.y), Space.Self);
            instantiatePrefab.transform.rotation = Quaternion.Lerp(transform.rotation, transform.rotation * Quaternion.FromToRotation(instantiatePrefab.transform.up, hit.normal), rotateTowardsNormal);
            }
            
        }
    }
    // Start is called before the first frame update

    public void Clear()
    {
        while (transform.childCount != 0)
        {
            DestroyImmediate(transform.GetChild(0).gameObject);
            
        }
       
    }
    void Start()
    {
        StartCoroutine(LateStart(0.5f));
        
    }

    IEnumerator LateStart(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Generate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
