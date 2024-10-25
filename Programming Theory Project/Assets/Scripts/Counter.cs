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

    public int fallenEnemyBalls = 0;
    public int fallenPlayerBalls = 0;


    private void Start()
    {
        fallenEnemyBalls = 0;
        fallenPlayerBalls = 0;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Enemy") {
            fallenEnemyBalls += 1;
            enemyCount.text = "Fallen Enemy Balls: " + fallenEnemyBalls;
        } else {
            fallenPlayerBalls += 1;
            playerCount.text = "Fallen Player Balls: " + fallenPlayerBalls + "/3";
        }
    }
}
