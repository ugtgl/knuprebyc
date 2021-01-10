using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScrollManager : MonoBehaviour
{
    private float scroll = 0; //toplanan scroll sayısı
    public TextMeshProUGUI textScroll; // UI scroll text kısmı
    public bool ScrollsCollected = false; // scrolların hepsi toplandı mı?
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.tag == "need") // eğer temas edilen objenin tagı need ise scroll miktarını artır ve UI'deki scroll kısmına yaz, ardından scroll'u yok et
        {
            scroll++;
            textScroll.text = "X" + scroll.ToString();
            Destroy(other.gameObject);
        }

    }

    void Update()
    {
        if(scroll == 3) // eğer 3 scroll toplanmışsa hepsi toplandı say
        {
            ScrollsCollected = true;

        }
    }



}

