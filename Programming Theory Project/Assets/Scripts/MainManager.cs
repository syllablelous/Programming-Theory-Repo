using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    private string username;

    private void Awake() {
        if (Instance != null) {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // ENCAPSULATION
    public string Username {
        get {
            return username;
        }
        private set {
            username = value;
        }
    }

    public void SetUsername(string newUsername) {
        if (!string.IsNullOrEmpty(newUsername)) {
            username = newUsername;
        } else {
            Debug.LogWarning("Invalid username!");
        }
    }
}
