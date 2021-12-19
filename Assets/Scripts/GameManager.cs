using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Public variables
    public List<GameObject> objects;
    public int score;
    public TextMeshPro timeText;
    public TextMeshPro scoreText;
    public GameObject buttons;
    public GameObject lifeMeter;
    public GameObject gameOverText;
    public GameObject restartButton;
    public GameObject[] lifeBar;
    public Camera mainCamera;
    

    //Private variables
    private Rigidbody rb;
    private float minValueX = -3.0f;
    private float maxValueZ = 4f;
    private bool isActive;
    private int playerLives = 3;
    private float spawnRate = 3f;
    private int timeLimit = 30;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        scoreText.transform.position = new Vector3(7.56f, 6.44f, 7f);
        gameOverText.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        TimeEnd();
    }


    IEnumerator SpawnGameObjects()
    {
        Debug.Log("Started spawning objects");
        while (isActive)
        {
            Debug.Log("Delaying...");
            yield return new WaitForSeconds(spawnRate);
            Debug.Log("Choosing prefab to spawn...");
            int randomObject = Random.Range(0, objects.Count);
            if (isActive)
            {
                Debug.Log("Spawning prefab...");
                Instantiate(objects[randomObject], RandomSpawnPosition(), objects[randomObject].transform.rotation);
            }
        }

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
        spawnRate /= difficulty;
        buttons.SetActive(false);
        lifeMeter.SetActive(true);
        scoreText.transform.position = new Vector3(7.56f, 6.44f, 6.3f);
        mainCamera.transform.Rotate(new Vector3(mainCamera.transform.rotation.x, 0f), 65f, Space.Self);
        if(mainCamera.transform.rotation.x >= 0.60f)
        {
            Debug.Log("Everything's set!");
            isActive = true;
            StartCoroutine(SpawnGameObjects());
            score = 0;
            StartCoroutine(TimeCountdown());
        }
        else
        {
            Debug.Log("Something's wrong");
            Debug.Log(mainCamera.transform.rotation.x);
        }
        

    }

    public void TrackScoreAndLives(int pointsToAdd, int reduceLives)
    {
        score += pointsToAdd;
        playerLives += reduceLives;

        scoreText.text = "Score: " + score;
        
        Debug.Log("Points: " + score + ", Lives: " + playerLives);

        switch (playerLives)
        {
            case 3:
                lifeMeter.SetActive(true);
                break;
            case 2:
                lifeBar[0].SetActive(false);
                break;
            case 1:
                lifeBar[0].SetActive(false);
                lifeBar[1].SetActive(false);
                break;
            case 0:
                lifeBar[0].SetActive(false);
                lifeBar[1].SetActive(false);
                lifeBar[2].SetActive(false);
                break;
            default:
                lifeMeter.SetActive(true);
                break;
        }

        if(playerLives == 0)
        {
            GameOver();
        }

    }

    public void GameOver()
    {
        isActive = false;
        Debug.Log("Game over!");
        gameOverText.SetActive(true);
        restartButton.SetActive(true);
        mainCamera.transform.Rotate(new Vector3(76f, 0f), -65f);

    }

    IEnumerator TimeCountdown()
    {
        while(isActive && timeLimit > -1)
        {
            timeText.text = "Time: " + timeLimit;
            yield return new WaitForSeconds(1);
            timeLimit -= 1;
        }
    }

    public void TimeEnd()
    {
        if(isActive && timeLimit == 0)
        {
            GameOver();
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
