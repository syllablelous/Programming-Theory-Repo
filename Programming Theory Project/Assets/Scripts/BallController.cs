using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    protected Rigidbody ballRb;
    protected float speed = 5.0f;

    protected float fallThreshold = -10.0f;

    // Start is called before the first frame update
    protected virtual void Start() {
        ballRb = GetComponent<Rigidbody>();
    }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    public virtual void Move(Vector3 direction) {
        ballRb.AddForce(direction * speed);
    }

    public virtual void CheckFall(){
        if (transform.position.y < fallThreshold) {
            Destroy(gameObject);
        }
    }

    
}
