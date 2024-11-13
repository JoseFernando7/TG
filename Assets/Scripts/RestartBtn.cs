using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartBtn : MonoBehaviour
{
    public void RestartScene()
    {
        // Load the current scene again using the name or index
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnClick()
    {
        RestartScene();
    }
}
