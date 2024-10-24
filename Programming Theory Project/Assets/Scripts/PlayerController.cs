using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BallController
{
    private GameObject focalPoint;
    private float powerupStrength = 15.0f;
    private Vector3 startPosition;
    public bool hasPowerup;
    public GameObject powerupIndicator;
    

    
    // Start is called before the first frame update
    protected override void Start() {
        base.Start();
        focalPoint = GameObject.Find("Focal Point");
        startPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update() {
        float forwardInput = Input.GetAxis("Vertical");
        Move(focalPoint.transform.forward * forwardInput);
        // playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);

        CheckFall();
    }

    public override void CheckFall() {
        if (transform.position.y < fallThreshold) {
            Respawn(); // Call respawn method if player fell from the platform.
        }
    }

    private void Respawn() {
        // Resets the player position to the initial spawn point.
        transform.position = startPosition;

        // Reset the player's velocity to avoid continuing to fall
        ballRb.velocity = Vector3.zero;
        ballRb.angularVelocity = Vector3.zero;

        Debug.Log("Player has respawned at the starting position!");
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Powerup")) {
            hasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
            powerupIndicator.gameObject.SetActive(true);
        }
    }

    IEnumerator PowerupCountdownRoutine() {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup) {

            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);

            Debug.Log("Collided with " + collision.gameObject.name + " with powerup set to " + hasPowerup);
            enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
        }
    }

    
}
