using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Public variables
    public List<GameObject> objects;

    //Private variables
    private Rigidbody rb;
    private float minValueX = -3.0f;
    private float maxValueZ = 4f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(SpawnGameObjects());
    }


    IEnumerator SpawnGameObjects()
    {
        yield return new WaitForSeconds(Random.Range(2f, 4f));
        int randomObject = Random.Range(0, objects.Count);
        Instantiate<GameObject>(objects[randomObject], RandomSpawnPosition(), objects[randomObject].transform.rotation);

    }

    Vector3 RandomSpawnPosition()
    {
        float[] randomSquareX = new float[3] { 0, 3, 6 };
        float[] randomSquareZ = new float[3] { 0, 2, 4 };

        int chooseX = Random.Range(0, randomSquareX.Length);
        int chooseZ = Random.Range(0, randomSquareZ.Length);

        float spawnPositionX = minValueX + randomSquareX[chooseX];
        float spawnPositionZ = maxValueZ - randomSquareZ[chooseZ];

        Vector3 spawnPosition = new Vector3(spawnPositionX, 5, spawnPositionZ);

        return spawnPosition;
    }

    public void StartGame(int difficulty)
    {
        StartCoroutine(SpawnGameObjects());
    }




}
