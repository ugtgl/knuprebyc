using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator explosion;
    public Canvas kanvas;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
    }
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5);
    }

}
