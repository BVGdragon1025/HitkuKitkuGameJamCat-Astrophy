using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeLimitButton : MonoBehaviour
{
    public int timeLimit;

    private GameManager gameManager;
    private DifficultyButton easyDifficulty;
    private DifficultyButton normalDifficulty;
    private DifficultyButton hardDifficulty;
    private Button timeButton;

    // Start is called before the first frame update
    void Start()
    {
        timeButton = GetComponent<Button>();
        easyDifficulty = GameObject.Find("Easy").AddComponent<DifficultyButton>();
        normalDifficulty = GameObject.Find("Normal").AddComponent<DifficultyButton>();
        hardDifficulty = GameObject.Find("Hard").AddComponent<DifficultyButton>();
        gameManager = GameObject.Find("SpawnPositions").AddComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
