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
    private float spawnRate = 1.0f;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    public void StartGame(int difficulty)
    {
        isGameActive = true;
        spawnRate /= difficulty;

        StartCoroutine(SpawnObstacle());
        

        titleScreen.gameObject.SetActive(false);
    }



    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }

    // Update is called once per frame
    void Update()
    {
            
    }
  

    IEnumerator SpawnObstacle()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            //int index = 0; 
            Instantiate(obstaclePrefab[0]);   
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}