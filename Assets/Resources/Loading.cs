using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    public Slider slider;
    float value = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        slider.value += value * Time.deltaTime * 10; 

    }

    public void loadScene(string loading)
    {
        SceneManager.LoadScene("Inside");
    }

}
