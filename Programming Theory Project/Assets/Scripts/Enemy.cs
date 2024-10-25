using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : BallController
{
    private GameObject player;
    private bool isGameOver = false;

    // Start is called before the first frame update
    protected override void Start() {
        base.Start();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update() {
        if (!isGameOver) {
            Vector3 lookDirection = (player.transform.position - transform.position).normalized;
            Move(lookDirection);

            CheckFall();
        } 
    }

    public void StopMovement() {
        isGameOver = true;
    }
}
