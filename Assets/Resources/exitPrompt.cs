using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class exitPrompt : MonoBehaviour
{
    public Canvas exit;
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
        if (collision.gameObject.name.Equals("Player"))
        exit.enabled = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
            exit.enabled = false;
    }
}
