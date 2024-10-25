using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Counter : MonoBehaviour
{
    public TextMeshProUGUI enemyCount;
    public TextMeshProUGUI playerCount;

    private int fallenEnemyBalls = 0;
    private int fallenPlayerBalls = 0;

    public int FallenEnemyBalls => fallenEnemyBalls;
    public int FallenPlayerBalls => fallenPlayerBalls;

    private void Start()
    {
        fallenEnemyBalls = 0;
        fallenPlayerBalls = 0;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Enemy") {
            IncrementEnemyCount();
        } else {
            IncrementPlayerCount();
        }
    }

    public void IncrementEnemyCount() {
        fallenEnemyBalls += 1;
        enemyCount.text = "Fallen Enemy Balls: " + fallenEnemyBalls;
    }

    public void IncrementPlayerCount() {
        fallenPlayerBalls += 1;
        playerCount.text = "Fallen Player Balls: " + fallenPlayerBalls + "/3";
    }

}
