using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private bool isGameOver = false;

    private void Awake() {
        if (Instance != null) {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void TriggerGameOver() {
        if (!isGameOver) {
            isGameOver = true;

            FindObjectOfType<SpawnManager>().GameOver();

            PlayerController player = FindObjectOfType<PlayerController>();
            if (player != null) {
                player.enabled = false;
            }

            StartCoroutine(LoadScoreScene());
        }
    }

    private IEnumerator LoadScoreScene() {
        Debug.Log("Game over! Transitioning to the score screen.");

        yield return new WaitForSeconds(2.0f);

        SceneManager.LoadScene("GameOver");
    }

    public bool IsGameOver => isGameOver;

}
