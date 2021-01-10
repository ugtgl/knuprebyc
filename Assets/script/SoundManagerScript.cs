using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip diamondSound, elevatorSound, clickSound, shotSound;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        
        diamondSound = Resources.Load<AudioClip>("diamond"); // elmas sesini yükle
        clickSound = Resources.Load<AudioClip>("click");
        shotSound = Resources.Load<AudioClip>("shot");
        audioSrc = GetComponent<AudioSource>(); // ses kaynağını ayarla

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound ( string clip)
    {
        switch (clip) // seslerden hangisi seçilecekse onu oynat
        {
            case "diamond":
                audioSrc.volume = 0.5f; // ses çok oluyor o yüzden sesi azalt
                audioSrc.PlayOneShot(diamondSound); // sesi bir kerelik oynat
                break;
            case "click":
                audioSrc.PlayOneShot(clickSound);
                break;
            case "shot":
                audioSrc.PlayOneShot(shotSound);
                break;
        }
    }
}
