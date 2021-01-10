using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyUnit : MonoBehaviour
{
    public Transform playerTransform;
    public float enemyUnitSpeed;
    bool hasSeenPlayer = false;
    public PlayerStats playerStats;
    float enemyHealth = 100;
    public TextMeshProUGUI enemyUnitHealthStatus;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyHealth < 100)
        {
            enemyUnitHealthStatus.text = enemyHealth.ToString();
        }
        
        if (hasSeenPlayer)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, enemyUnitSpeed * Time.deltaTime);
        }
        if(enemyHealth <= 0)
        {
            Destroy(gameObject);
            playerStats.totalScore += 1000;
        }
        Debug.Log(enemyHealth);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            Debug.Log("ok");
            hasSeenPlayer = true;
        }
        if (collision.gameObject.name.Equals("bullet"))
        {
            GetDamage(5);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            playerStats.GetDamage(1);
        }
    }

    private void GetDamage(float damage)
    {
        enemyHealth -= damage;
    }
}
