using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    
    public GameObject[] obstaclePrefab;
    private Vector3 spawnPos = new Vector3(30, 1, 0);
    private float startDelay = 2;
    private float repeatRate = 2;
    private PlayerController playerControllerScript;
    public GameObject titleScreen;
    public bool isGameActive;
    private int score;
    private float spawnRate = 1.0f;
    public TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    public void StartGame(int difficulty)
    {
        isGameActive = true;
        score = 0;
        spawnRate /= difficulty;

        StartCoroutine(SpawnObstacle());
        UpdateScore(0);
        

        titleScreen.gameObject.SetActive(false);
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
            
    }

    void SpawnObstacle()
    {
        if (playerControllerScript.gameOver == false)
        {
            int animalIndex = Random.Range(0, obstaclePrefab.Length);
            Instantiate(obstaclePrefab[animalIndex], new Vector3(30, 1, 0), obstaclePrefab[animalIndex].transform.rotation);
        }
    }

   

}
