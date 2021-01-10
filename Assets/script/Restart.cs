using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public string scene;
    public void RestartScene()
    {
        scene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(scene);
    }
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("New Scene");
    }

}
