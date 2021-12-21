using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    private float countdown = 1.5f;
    private Rigidbody rb;
    private GameManager gameManager;
    private AudioSource audioSource;

    public int addPoints;
    public int subtractLives;
    public AudioClip[] catSounds;
    public AudioClip[] mouseSounds;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("SpawnPositions").GetComponent<GameManager>();
        audioSource = GameObject.Find("Arcade").GetComponent<AudioSource>();
        StartCoroutine(DestroyObject());
    }

    // Update is called once per frame
    void Update()
    {
        CheckForClick();
        RandomCatMeow();

    }

    IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(countdown);
        Destroy(gameObject);
        Debug.Log("Object: " + gameObject.name + " destroyed after " + countdown + "s");

    }

    private void CheckForClick()
    {
        if(Input.GetAxis("Fire1") > 0 )
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == gameObject.name)
                {
                    Destroy(gameObject);
                    Debug.Log("Object: " + gameObject.name + " destroyed by player");
                    if (gameObject.CompareTag("BadObject"))
                    {
                        gameManager.TrackScoreAndLives(addPoints,subtractLives);
                        audioSource.PlayOneShot(RandomCatMeow(),0.25f);
                    }
                    else
                    {
                        gameManager.TrackScoreAndLives(addPoints,subtractLives);
                        audioSource.PlayOneShot(mouseSounds[0],0.25f);
                    }
                }
            }

            
        }
        
        
    }

    public AudioClip RandomCatMeow()
    {
        int randomSound = Random.Range(0, catSounds.Length);
        return catSounds[randomSound];
    }

}
