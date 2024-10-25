using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized.
[DefaultExecutionOrder(1000)]

public class MenuUIHandler : MonoBehaviour
{
    // [SerializeField] private GameObject usernameInput;
    // [SerializeField] private Button startButton;
    // Start is called before the first frame update
    private string input;
    void Start() {
        // var input = gameObject.GetComponent<InputField>();
        // var se = new InputField.SubmitEvent();
        // se.AddListener(SubmitName);
        // input.onEndEdit = se;
    }

    private void StartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void SubmitName() {
        if (input != null) {
            StartGame();
        }
    }

    // Update is called once per frame
    void Update() { }

    public void ReadStringInput(string s) {
        input = s;
        Debug.Log(input);
    }
}
