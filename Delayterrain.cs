using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delayterrain : MonoBehaviour
{
    public GameObject[] terrainitems;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LateStart(3f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator LateStart(float waitTime){
         yield return new WaitForSeconds(waitTime);
         for (int i=0; i<terrainitems.Length;i++){
            terrainitems[i].SetActive(true);
         }
    }

}
