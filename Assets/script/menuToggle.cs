using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuToggle : MonoBehaviour
{
    public GameObject menu;
    public bool menuOpened = false;
    // Start is called before the first frame update
    void Start()
    {
        menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void showMenu()
    {
        menu.SetActive(true);
        Time.timeScale = 0;
        SoundManagerScript.PlaySound("click");
        menuOpened = true;
    }
    public void hideMenu()
    {
        menu.SetActive(false);
        Time.timeScale = 1;
        SoundManagerScript.PlaySound("click");
        menuOpened = false;
    }
}
