using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class DisplayScores : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI playerText;
    public TextMeshProUGUI hiScoreText;

    public static DisplayScores Instance { get; private set; }

    public string playerName;
    public int playerScore;
    public int highestScore;

    private void Awake() {
        if (Instance != null) {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadData();
    }

    [System.Serializable]
    class SaveData {
        public int sdHighestScore;
    }

    public void WriteData() {
        SaveData data = new SaveData();
        data.sdHighestScore = highestScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadData() {
        string filePath = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(filePath)) {
            string json = File.ReadAllText(filePath);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highestScore = data.sdHighestScore;
        }
    }
    // Start is called before the first frame update
    void Start() {
        DisplayDetails();
    }

    // ABSTRACTION
    public void DisplayDetails() {
        playerScore = GameManager.Instance.GameScore;
        playerName = MainManager.Instance.Username;

        LoadData();

        if (highestScore != 0) {
            if (playerScore > highestScore) {
                highestScore = playerScore;
            }
        } else {
            highestScore = playerScore;
        }

        scoreText.text = "" + playerScore;
        playerText.text = "" + playerName;
        hiScoreText.text = "" + highestScore;
    }

    // ABSTRACTION
    public void GameAgain() {
        WriteData();

        playerName = string.Empty;
        playerScore = 0;

        Destroy(GameManager.Instance.gameObject);
        Destroy(MainManager.Instance.gameObject);

        Destroy(this.gameObject);

        SceneManager.LoadScene("Menu");
    }
}