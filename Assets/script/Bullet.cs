﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy") // eğer düşmansa
        {
            Destroy(collision.gameObject); // düşmanı yok et veya ortadan kaldır
        }
    }*/
    private void OnCollisionEnter2D (Collision2D collision)
    {

    }
}
