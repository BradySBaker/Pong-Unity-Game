using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class PlayButtonController : MonoBehaviour
{
    public TMP_InputField winPointsField;
    public TMP_InputField enemySpeedField;
    void Start()
    {
        if (winPointsField == null || enemySpeedField == null) {
            Debug.LogError("Please provide input fields");
        }
    }

    public void OnButtonPress() {
        bool validWinPoints = int.TryParse(winPointsField.text, out int winPoints);
        bool validEnemySpeed = float.TryParse(enemySpeedField.text,out float enemySpeed);
        if (validWinPoints && validEnemySpeed) {
            PlayerPrefs.SetInt("winPoints", winPoints);
            PlayerPrefs.SetFloat("enemySpeed", enemySpeed);
            SceneManager.LoadScene(1);
        }
    }
}
