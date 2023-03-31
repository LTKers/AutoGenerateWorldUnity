using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Objectplacement : MonoBehaviour
{
    public GameObject[] itemstopickfrom;
    public float overlapTestBoxSize = 1f;
    public LayerMask spawnedObjectLayer;

    [SerializeField] Vector2 xRange;
    [SerializeField] Vector2 zRange;
    // Start is called before the first frame update
    void Start()
    {
        PositionRaycast();
    }

    void PositionRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity)) 
        {
            Quaternion spawnRotation = Quaternion.FromToRotation(Vector3.up, hit.normal);

            Vector3 overlaptestboxscale = new Vector3(overlapTestBoxSize, overlapTestBoxSize, overlapTestBoxSize);
            Collider[] colliderInsideOverLapBox = new Collider[1];
            int numberOfCollidersFound = Physics.OverlapBoxNonAlloc(hit.point, overlaptestboxscale, colliderInsideOverLapBox, spawnRotation, spawnedObjectLayer);
            
            if (numberOfCollidersFound == 0)
            {
                Pick(hit.point, spawnRotation);
            }
        }
    }


    void Pick(Vector3 positionToSpawn, Quaternion rotationToSpawn)
    {
        int randomIndex = Random.Range(0, itemstopickfrom.Length);
        GameObject clone = Instantiate(itemstopickfrom[randomIndex], positionToSpawn, rotationToSpawn);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
