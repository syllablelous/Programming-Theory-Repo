using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    protected Rigidbody ballRb;
    protected float speed = 5.0f;

    protected float fallThreshold = -10.0f;


    protected virtual void Start() {
        ballRb = GetComponent<Rigidbody>();
    }

    public virtual void Move(Vector3 direction) {
        ballRb.AddForce(direction * speed);
    }

    public virtual void CheckFall(){
        if (transform.position.y < fallThreshold) {
            Destroy(gameObject);
        }
    }
}
