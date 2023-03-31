using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemspread : MonoBehaviour
{
    // Start is called before the first frame update

public GameObject[] itemstopickfrom;
    public GameObject itemToSpread;

  
    public int numItemsToSpawn = 50;
    public float itemXSpread=10;
    public float itemYSpread;
    public float itemZspread=10;
    private Vector3 scale;
    public LayerMask spawnedObjectLayer;
    public int Rep=0;

    public int spawncollisioncheckradius=10;
    [SerializeField] Vector2 xRange;
    [SerializeField] Vector2 zRange;
    void Start()
    {
        StartCoroutine(LateStart(1f));
        
    }
    IEnumerator LateStart(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        
            StartCoroutine(LateCount(2f));
        
        
    }
    IEnumerator LateCount(float waitTime){
         yield return new WaitForSeconds(waitTime);
for (int i = 0; i < numItemsToSpawn; i++)
        {
            SpreadItem();
        }
    }
    void SpreadItem()
    {
        Vector3 randPosition = new Vector3(Random.Range(0, itemXSpread), Random.Range(-itemYSpread, itemYSpread), Random.Range(0, itemZspread))+transform.position;
        GameObject clone2 = Instantiate(itemToSpread, randPosition, Quaternion.identity);
    Debug.Log("yes");
        if (!Physics.CheckSphere(clone2.transform.position, spawncollisioncheckradius, spawnedObjectLayer)){
             RaycastHit hit;
             Debug.Log("non");
        if (Physics.Raycast(clone2.transform.position, Vector3.down, out hit, Mathf.Infinity))
        {
            Quaternion spawnRotation = Quaternion.FromToRotation(Vector3.up, hit.normal);

         
            Pick(hit.point);
            Destroy(clone2);
        
        }
        }
        else{
            Destroy(clone2);
           
        }
       

           // Vector3 overlaptestboxscale = new Vector3(overlapTestBoxSize, overlapTestBoxSize, overlapTestBoxSize);
           // Collider[] colliderInsideOverLapBox = new Collider[1];
      
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
        Destroy(clone2);
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
