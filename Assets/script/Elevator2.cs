using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator2 : MonoBehaviour
{
    private bool collided;
    public Transform pos1, pos2;
    public float speed;
    public float acceleration;
    public float deceleration;
    public float maxSpeed;
    public Transform startPos;
    Vector3 nextPos;
    public ScrollManager scrollManager;
    public AudioSource audioSource;
    bool PlaySound;
    public playerChecker playerChecker;


    public void OnCollisionEnter2D(Collision2D collision) // eğer oyuncu asansöre değmişse ikisinin transformları kilitlenir
    {
        if (collision.gameObject.name == "Player")
        {
            collided = true;
            collision.transform.parent = transform;
        }

    }

    public void OnCollisionExit2D(Collision2D collision) // eğer oyuncu asansör ile teması kesmiş ise yani asansörden inmişse? transformlar kilitli değildir ve asansör oyuncunun parent'ı olmaz
    {
        if (collision.gameObject.name == "Player")
        {
            collided = false;
            collision.transform.parent = null;
        }
    }
    void Awake() // başka class'a erişim için
    {
        scrollManager = GameObject.FindObjectOfType<ScrollManager>();
    }


    // Start is called before the first frame update
    void Start()
    {
        nextPos = startPos.position; // asansörün gideceği konum şu anda başlama pozisyonu ki durur halde beklesin
        //acceleration = 0.5f;
        //deceleration = 0.5f;
        speed = 0.0f;
        maxSpeed = 1.0f;
        PlaySound = true;
        //acceleration = (-(x * x)) + 1;
        //deceleration = (-(x * x)) + 1;
    }
    public float accelerate(float x) // ivmelenme fonksiyonu. -(x^2)+1 denklemini kullanır
    {
        return ((-(x * x)) + 1) / 10;
    }
    public float decelerate(float y) // yavaşlama fonksiyonu. bu da -(x^2)+1 denklemini kullanır
    {
        return ((-(y * y)) + 1) / 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (collided && scrollManager.ScrollsCollected && playerChecker.playerAnswer == true) // eğer asansöre binilmişse ve scrollar toplanmış ise
        {
            if ((Input.GetKey(KeyCode.E)) && (speed < maxSpeed)) // eğer asansör belirtilen hıza ulaşmamış ise ve tuşa basılıyor ise
            {
                if (speed < 1) // asansör hızı 1'in altındaysa
                {
                    for (float i = -1.01f; i < 0; i += 0.1f) // ivmelendir. f(x) = -(x^2)+1 denkleminde x değerlerini bul, f(x)'i hesapla ve hıza ekle
                    {
                        speed = speed + accelerate(i) * Time.deltaTime;
                    }

                }



                if (PlaySound == true) // eğer ses çalıyorsa
                {
                    audioSource.loop = true; // sesi loop moduna sok
                    audioSource.Play(); // sesi oynat
                    PlaySound = false; // ses çalmıyor durumuna sok
                }
                if (audioSource.isPlaying == false) // ses çalmıyorsa
                {
                    //StartCoroutine(Wait());
                    PlaySound = true; // ses çalıyor artık durumuna sok
                }

            }

            else if ((Input.GetKey(KeyCode.E)) && (speed > -maxSpeed) && playerChecker.playerAnswer == true) //yukarıdakinin biraz farklısı, burada anlık hız maksimum hızdan fazla ise
            {
                if (speed < 1)
                {
                    for (float j = -1.01f; j < 0; j += 0.1f)
                    {
                        speed = speed + accelerate(j) * Time.deltaTime;
                    }
                }
            }
            else
            {
                audioSource.loop = false; // loop durumundan çıkar
                if (speed > deceleration * Time.deltaTime) // eğer hız yavaşlama ivmesinden büyük ise
                {
                    for (float n = 0; n < 1.01f; n += 0.1f)
                    {
                        speed = speed - decelerate(n) * Time.deltaTime; // hızı azalt
                    }
                }
                else if (speed < -deceleration * Time.deltaTime) // eğer hız yavaşlama ivmesinden küçük ise
                {
                    for (float m = -1.01f; m < 0; m += 0.1f)
                    {
                        speed = speed + decelerate(m) * Time.deltaTime; // hıza yavaşlama ivmesi ekle ama aslında hızlandır çünkü for döngüsünde x değerleri f(x) değerlerinin artmasına neden oluyor
                    }

                }
                else
                    speed = 0; // eğer üsttekilerin hiç biri sağlanmıyorsa hız sıfırdır
            }

            if (transform.position == pos1.position) // eğer birinci pozisyondaysa
            {
                //if (Input.GetKeyDown(KeyCode.W))
                nextPos = pos2.position; // ikinci pozisyona git
            }
            if (transform.position == pos2.position) // eğer ikinci pozisyondaysa
            {
                //if (Input.GetKeyDown(KeyCode.S))
                nextPos = pos1.position; // birinci pozisyona git
            }
            transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime); // hareket et


        }

        if (Input.GetKey(KeyCode.K)) // asansörü binmeden test edebilmek için
        {
            if (transform.position == pos1.position)
            {
                //if (Input.GetKeyDown(KeyCode.W))
                nextPos = pos1.position;
            }
            if (transform.position == pos2.position)
            {
                //if (Input.GetKeyDown(KeyCode.S))
                nextPos = pos2.position;
            }
            transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
        }

    }
    IEnumerator Wait() // bekleme metodu fakat gerek kalmadı
    {
        yield return new WaitForSeconds(0.0001f);
        PlaySound = true;
    }
}

