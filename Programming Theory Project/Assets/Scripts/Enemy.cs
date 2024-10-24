using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : BallController
{
    private GameObject player;

    // Start is called before the first frame update
    protected override void Start() {
        base.Start();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update() {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        Move(lookDirection);

        CheckFall();
    }
}
