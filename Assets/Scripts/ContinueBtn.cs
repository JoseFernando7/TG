using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueBtn : MonoBehaviour
{
    public void Continue()
    {
        SceneManager.LoadScene(sceneName:"SampleScene");
    }
}
