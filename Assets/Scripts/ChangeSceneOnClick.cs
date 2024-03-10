using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public int sceneChoice = 0;
    public void OnButtonPress() {
        SceneManager.LoadScene(sceneChoice);
    }
}
