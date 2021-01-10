using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DiamondManager : MonoBehaviour
{
    public float diamond = 0;
    public TextMeshProUGUI textDiamond;
    public bool DiamondsCollected = false;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "diamond") // eğer temas edilmiş nesne elmas ise
        {
            diamond++; // elmas sayısını artır
            textDiamond.text = "X" + diamond.ToString(); // UI'ye elmas miktarını yaz
            Destroy(other.gameObject); // elması yok et
            SoundManagerScript.PlaySound("diamond"); // ses oynat
        }

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
