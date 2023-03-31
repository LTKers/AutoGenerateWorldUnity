using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Raycastspawner : MonoBehaviour
{
    public GameObject[] itemstopickfrom;
    public float overlapTestBoxSize = 1000f;
    public LayerMask spawnedObjectLayer;
    private Vector3 scale;
    [SerializeField] Vector2 xRange;
    [SerializeField] Vector2 zRange;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
         StartCoroutine(LateStart(1f));
    
    }
    void OnTriggerEnter(Collider col){
        Debug.Log("hit");
        Debug.Log("Recalculate");
        Recalculate();
        
    }
    IEnumerator LateStart(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        PositionRaycast();
        Debug.Log("Done");
    }
    void Recalculate(){
        gameObject.transform.position=new Vector3(Random.Range(-48, 48), 0, Random.Range(-48,48))+transform.position;
    }
    void PositionRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity))
        {
            Quaternion spawnRotation = Quaternion.FromToRotation(Vector3.up, hit.normal);

          //  Vector3 overlaptestboxscale = new Vector3(overlapTestBoxSize, overlapTestBoxSize, overlapTestBoxSize);
//Collider[] colliderInsideOverLapBox = new Collider[1];
            Pick(hit.point);
            //int numberOfCollidersFound = Physics.OverlapBoxNonAlloc(hit.point, overlaptestboxscale, colliderInsideOverLapBox, spawnRotation, spawnedObjectLayer);
           // Debug.Log(numberOfCollidersFound);
          //  if (numberOfCollidersFound == 0)
           // {
         //      
        //    }
       //     else
        //    {
        //        PositionRaycast();
       //     }
        }
    }


    void Pick(Vector3 positionToSpawn)
    {
        Quaternion randYRotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
        int randomIndex = Random.Range(0, itemstopickfrom.Length);
        float randomscale = Random.Range(1.0f, 1.75f);
        scale = new Vector3(randomscale, randomscale, randomscale);
        GameObject clone = Instantiate(itemstopickfrom[randomIndex], positionToSpawn, randYRotation);
        clone.transform.localScale = scale;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
