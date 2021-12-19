using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DifficultyButton : MonoBehaviour
{
    public int difficulty;
    public GameObject bakedText;

    private GameManager gameManager;
    private Button diffButton;

    // Start is called before the first frame update
    void Start()
    {
        diffButton = GetComponent<Button>();
        gameManager = GameObject.Find("SpawnPositions").GetComponent<GameManager>();
        diffButton.onClick.AddListener(SetDifficulty);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SetDifficulty()
    {
        gameManager.StartGame(difficulty);
        bakedText.SetActive(true);
    }



}
