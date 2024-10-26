using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SpawnManager : MonoBehaviour
{
    private float spawnRange = 9;

    public GameObject enemyPrefab;
    public int enemyCount;
    public int waveNumber = 1;
    public GameObject powerupPrefab;

    private bool isGameOver = false;

    // Start is called before the first frame update
    void Start() {
        if (!isGameOver) {
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
            SpawnEnemyWave(waveNumber);
        }
    }

    // Update is called once per frame
    void Update() {
        if (!isGameOver) {
            enemyCount = FindObjectsOfType<Enemy>().Length;
            if (enemyCount == 0) {
                Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
                waveNumber++;
                SpawnEnemyWave(waveNumber);
            }
        }
    }

    private Vector3 GenerateSpawnPosition() {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }

    void SpawnEnemyWave(int enemiesToSpawn) {
        if (!isGameOver) {
            for (int i = 0; i < enemiesToSpawn; i++) {
                Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
            }
        }
    }

    public void GameOver() {
        isGameOver = true;
        Debug.Log("Game Over! Stopping all enemy spawns and movement.");

        Enemy[] enemies = FindObjectsOfType<Enemy>();
        foreach (Enemy enemy in enemies) {
            enemy.StopMovement();
        }
    }
}
