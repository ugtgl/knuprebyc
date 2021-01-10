using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class exitTunnel : MonoBehaviour
{
    public TextMeshProUGUI exit;
    // Start is called before the first frame update
    void Start()
    {
        exit.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        exit.enabled = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        exit.enabled = false;
    }

    public void exitTunel()
    {
        SceneManager.LoadScene("New Scene");
    }
}
