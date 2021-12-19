using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    //Public variables
    

    //Private variables
    
    private int countdown = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    IEnumerator RemoveSpawnedObject()
    {
        yield return new WaitForSeconds(countdown);
        transform.Translate(new Vector3(0, 0, 0), Space.World);
        StartCoroutine(RemoveSpawnedObject());
    }

}
