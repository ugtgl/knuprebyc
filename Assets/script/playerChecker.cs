using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerChecker : MonoBehaviour
{
    public bool playerTouch = false;
    public GameObject checkpointCanvas;
    public bool playerAnswer;
    public ObjectiveManager objectiveManager;
    // Start is called before the first frame update
    void Start()
    {
        checkpointCanvas.SetActive(false);
        playerAnswer = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerTouch = true;
            checkpointCanvas.SetActive(true);
            objectiveManager.objectiveStatus.text = "Use the second elevator and enter the building.";
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerTouch = false;
            checkpointCanvas.SetActive(false);
        }
    }
    public void GetPermission()
    {
        playerAnswer = true;
        checkpointCanvas.SetActive(false);
    }
}
