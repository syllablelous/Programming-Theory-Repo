using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayScores : MonoBehaviour
{
    // public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start() {
        int playerScore = GameManager.Instance.GameScore;
        string playerName = MainManager.Instance.Username;

        Debug.Log("Congratulations " + playerName + "! You got a score of: " + playerScore);
    }

}
