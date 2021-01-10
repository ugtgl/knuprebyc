using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFall : MonoBehaviour
{
    public Transform Player;
    public Transform Plat;
    public GameObject Platobj;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

            if (Vector3.Distance(Player.transform.position, Plat.transform.position) < 0.3f)
            {

                rb.isKinematic = false;
            }


    }
}
