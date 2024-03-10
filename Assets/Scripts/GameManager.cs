using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public TextMeshProUGUI player1TextScore; // Instance variable
    public TextMeshProUGUI player2TextScore; // Instance variable

    private int player1Score = 0; // Static variable
    private int player2Score = 0; // Static variable

    private int pointsToWin = 1;

    private void Start() {
        pointsToWin = PlayerPrefs.GetInt("winPoints");
    }
    public void ScorePoint(string side) {
        if (side == "Left") {
            player2Score++;
        } else {
            player1Score++;
        }
        UpdateScore(); // Call static method from static method
        if (player1Score >= pointsToWin) {
            PlayerPrefs.SetInt("Win", 1);
            SceneManager.LoadScene(2);
        } else if (player2Score >= pointsToWin) {
            PlayerPrefs.SetInt("Win", 2);
            SceneManager.LoadScene(2);
        }
    }

    private void UpdateScore() {
        if (player1TextScore != null && player2TextScore != null) {
            player1TextScore.text = player1Score.ToString();
            player2TextScore.text = player2Score.ToString();
        } else {
            Debug.LogError("Text scores are not assigned in the Inspector.");
        }
    }
}
