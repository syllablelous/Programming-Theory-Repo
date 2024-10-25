using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    [SerializeField] private bool autoRotate = false;
    public float rotationSpeed = 2.0f;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (autoRotate) {
            AutoRotate();
        } else {
            rotationSpeed = 15.0f;

            float horizontalInput = Input.GetAxis("Horizontal");
            transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);
        }
    }

    public void AutoRotate() {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
