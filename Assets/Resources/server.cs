using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class server : MonoBehaviour
{
    float serverHealth = 100;
    public TextMeshProUGUI serverHealthStatus;
    public ObjectiveManager objectiveManager;
    public PlayerStats playerStats;
    // Start is called before the first frame update
    void Start()
    {
        serverHealthStatus.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(serverHealth < 100)
        {
            serverHealthStatus.enabled = true;
            serverHealthStatus.text = "Server health:" + serverHealth.ToString();
        }
        if(serverHealth <= 0)
        {
            Destroy(gameObject);
            playerStats.totalScore += 5000;
            objectiveManager.objectiveStatus.text = "The server has been destroyed. Now head to the exit.";
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("bullet"))
        {
            serverHealth -= 10;
        }
    }
}
