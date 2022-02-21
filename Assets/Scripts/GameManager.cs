using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject mainMenuPanel;
    [SerializeField] GameObject instructionsPanel;
    [SerializeField] GameObject gameOverPanel;

    [SerializeField] GameObject player;
    [SerializeField] GameObject coinSpawnner;
    [SerializeField] GameObject timerManager;

    [SerializeField] TMP_Text scoreText;

    private int score = 0;

 
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        mainMenuPanel.SetActive(true);
        instructionsPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        player.GetComponent<PlayerController>().canMove = false;
        coinSpawnner.GetComponent<CollectibleSpawnner>().canSpawn = false;
        timerManager.SetActive(false);
    }

    public void PlayGameButton()
    {
        mainMenuPanel.SetActive(false);
        instructionsPanel.SetActive(true);
    }

    public void OnStartGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        instructionsPanel.SetActive(false);
        player.GetComponent<PlayerController>().canMove = true;
        coinSpawnner.GetComponent<CollectibleSpawnner>().canSpawn = true;
        timerManager.SetActive(true);
        timerManager.GetComponent<TimeManager>().OnStartGame();
    }

    public void OnGameOver()
    {
        Cursor.lockState = CursorLockMode.None;
        gameOverPanel.SetActive(true);
        scoreText.SetText(score.ToString());
        player.GetComponent<PlayerController>().canMove = false;
        coinSpawnner.GetComponent<CollectibleSpawnner>().canSpawn = false;
        ObjectPooler.instance.OnGameOverHideObjects();
        timerManager.SetActive(false);
    }

    public void MainMenuEvent()
    {
        mainMenuPanel.SetActive(true);
        score = 0;
        instructionsPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        player.GetComponent<PlayerController>().canMove = false;
        coinSpawnner.GetComponent<CollectibleSpawnner>().canSpawn = false;
        timerManager.SetActive(false);
    }

    public void PlayAgain()
    {
        Cursor.lockState = CursorLockMode.Locked;
        score = 0;
        gameOverPanel.SetActive(false);
        player.GetComponent<PlayerController>().canMove = true;
        coinSpawnner.GetComponent<CollectibleSpawnner>().canSpawn = true;
        timerManager.SetActive(true);
        timerManager.GetComponent<TimeManager>().OnStartGame();
    }

    public void QuitApplication()
    {
        Application.Quit();
    }

    public void IncrementScore()
    {
        score += 10;
    }
}
