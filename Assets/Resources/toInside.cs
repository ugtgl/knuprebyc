using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class toInside : MonoBehaviour
{
    public GameObject goInside;

    // Start is called before the first frame update
    void Start()
    {
        goInside.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("DENEME");
        goInside.SetActive(true);

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        goInside.SetActive(false);
    }
    public void goInsideMethod()
    {
        SceneManager.LoadScene("Inside");
    }
}
