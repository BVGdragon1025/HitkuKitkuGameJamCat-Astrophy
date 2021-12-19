using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    [SerializeField] private float countdown = 1f;
    private Rigidbody rb;
    private GameManager gameManager;
    public int addPoints;
    public int subtractLives;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("SpawnPositions").GetComponent<GameManager>();

        StartCoroutine(DestroyObject());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sensor"))
        {
            Destroy(gameObject);
        }
    }*/

    IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(countdown);
        Destroy(gameObject);
        Debug.Log("Object: " + gameObject.name + " destroyed after " + countdown + "s");

    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
        Debug.Log("Object: " + gameObject.name + " destroyed by player");
        if (gameObject.CompareTag("BadObject"))
        {
            gameManager.TrackScoreAndLives(addPoints,subtractLives);
        }
        else
        {
            gameManager.TrackScoreAndLives(addPoints,subtractLives);
        }
        
    }

    

}
