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
    // Start is called before the first frame update
    private string input;

    private void StartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void SubmitName() {
        if (!string.IsNullOrEmpty(input)) {
            MainManager.Instance.SetUsername(input);
            StartGame();
        } else {
            Debug.Log("Error! Please enter your name first before proceeding.");
        }
    }

    public void ReadStringInput(string s) {
        input = s;
        Debug.Log(input);
    }

    
}
