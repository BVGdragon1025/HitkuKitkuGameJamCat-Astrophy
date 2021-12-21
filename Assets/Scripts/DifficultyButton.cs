using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class DifficultyButton : MonoBehaviour
{
    public int difficulty;
    public GameObject bakedText;
    public TextMeshPro textAbove;


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
        textAbove.text = "Chosen difficulty";
    }


}
