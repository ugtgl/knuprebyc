using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow2 : MonoBehaviour
{
    public Transform player;
    // Start is called before the first frame update
    private void FixedUpdate() // kameranın oyuncuyu takip etmesi
    {
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }
}
