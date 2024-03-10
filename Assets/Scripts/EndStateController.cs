using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndStateController : MonoBehaviour
{
    public TMP_Text endState;
    void Start()
    {
        if (PlayerPrefs.GetInt("Win") == 1) {
            endState.text = "You Win!";
            endState.color = Color.green;
        } else
        {
            endState.text = "You Lose!";
            endState.color = Color.red;
        }
    }

}
