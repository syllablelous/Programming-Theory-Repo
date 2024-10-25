using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private bool isGameOver = false;
    private int gameScore;


    private void Awake() {
        if (Instance != null) {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void TriggerGameOver() {
        Counter counter = FindObjectOfType<Counter>();

        if (!isGameOver) {
            SetScore(counter.FallenEnemyBalls);
            isGameOver = true;

            FindObjectOfType<SpawnManager>().GameOver();

            PlayerController player = FindObjectOfType<PlayerController>();
            if (player != null) {
                player.enabled = false;
            }

            StartCoroutine(LoadGameOverScene());
        }
    }

    public int GameScore {
        get {
            return gameScore;
        }
        private set {
            gameScore = value;
        }
    }

    public void SetScore(int score) {
        gameScore = score;
    }

    private IEnumerator LoadGameOverScene() {
        Debug.Log("Game over! Transitioning to the score screen.");

        yield return new WaitForSeconds(2.0f);

        SceneManager.LoadScene("GameOver");
    }

}
