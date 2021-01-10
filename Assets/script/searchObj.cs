using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class searchObj : MonoBehaviour
{
    GameObject[] platforms;
    GameObject currentPoint;
    public GameObject Player;
    int flag;
    Rigidbody2D rb;
    int index;
    int[] dizi;
    // Start is called before the first frame update
    void Start()
    {
        dizi = new int[20]; // 20 elemanlı bir dizi oluştur
        platforms = GameObject.FindGameObjectsWithTag("platform2"); // platform2 taglı objeleri seç

        for (int j = 0; j < platforms.Length; j++) // ne kadar platform2 taglı obje varsa o kadar döndür
        {
            dizi[j] = Random.Range(0, 2); // rasgele üretilen 1 veya 0 değerlerini diziye ata
            Debug.Log(dizi[j]);
        }

        //Destroy(currentPoint);
        //print(currentPoint.name);

    }

    // Update is called once per frame
    void Update()
    {

        for (int i = 0; i < platforms.Length; i++) // ne kadar platform2 objesi varsa
        {
            //index = Random.Range(0, platforms.Length);
            currentPoint = platforms[i]; // anlık eleman
            rb = currentPoint.GetComponent<Rigidbody2D>(); // anlık elemanın rigidbodysini değişkene ata
            if (Vector3.Distance(Player.transform.position, currentPoint.transform.position) < 0.2f && dizi[i] == 1) // eğer anlık eleman yani platform nesnesi oyuncuya belirtilen mesafede ve anlık dizi değeri 1 ise
            {
                rb.isKinematic = false; // platformu düşür
            }
        }

    }





}
