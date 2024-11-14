using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSimu : MonoBehaviour
{
    public void StartSimulator()
    {
        Debug.Log("Starting the simulator...");
        SceneManager.LoadScene("WarningScene");
    }
}
