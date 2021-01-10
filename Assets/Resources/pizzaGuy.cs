using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pizzaGuy : MonoBehaviour
{
    public Transform checkpoint;
    public Transform checkpoint2;
    bool reached = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(reached == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, checkpoint2.position, 0.5f * Time.deltaTime);
        }
        
        if(reached == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, checkpoint.position, 0.5f * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("pizzaGuyCheckpoint"))
        {
            reached = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("pizzaGuyCheckpoint"))
        {
            reached = false;
        }
    }
}
