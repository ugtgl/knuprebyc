using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaceMarine : MonoBehaviour
{
    public GameObject spacemarine;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("space-marine-shoot_0"))
        {
            Destroy(spacemarine);
        }
    }
}
