using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] backgroundObjects;
    public GameObject[] enemyObjects;

    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnBackgroundObject());
        StartCoroutine(SpawnEnemyObject());
    }

    // Update is called once per frame
    void Update()
    {   
        
    }


    IEnumerator SpawnEnemyObject()
    {
        int pickObject = Random.Range(0, enemyObjects.Length);
        Instantiate<GameObject>(enemyObjects[pickObject], new Vector3( 0, 0, 0), enemyObjects[pickObject].transform.rotation);
        yield return new WaitForSeconds(Random.Range(3f, 6f));
        StartCoroutine(SpawnEnemyObject());
    }

    IEnumerator SpawnBackgroundObject()
    {
        int pickObject = Random.Range(0, backgroundObjects.Length);
        Instantiate<GameObject>(backgroundObjects[pickObject], new Vector3(0, 0, 7), backgroundObjects[pickObject].transform.rotation);
        yield return new WaitForSeconds(Random.Range(4f, 10f));
        StartCoroutine(SpawnBackgroundObject());
        
    }

}
