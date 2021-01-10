using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float speed;
    public float turnDelay;
    public int health;
    bool faceRight = false;
    Rigidbody2D rb;
    public Animator animator;
    public GameObject PlayerStats;
    public bool flagfalan = false;
    public Animator animatorPlayer;
    public Transform playerTransform;
    bool hasSeenPlayer = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // obje rigidbodysini değişkene ata
        StartCoroutine(SwitchDirections()); // yön değiştirme yan rutini başlat
    }
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    { // mermi sistemi eklendi bu kısım çıkarılacak
        /*if (flagfalan == true && PlayerStats.GetComponent<PlayerStats>().isTired == false ) // eğer karaktere temas edilmişse ve karakter yorulmamışsa
        {
            if (Input.GetKey(KeyCode.Mouse0)) // sol klik basıldığı sürece
            {

            }
            //flagfalan = false; // temas ortadan kalmış ise boolean değerini değiştir
        }*/
        if (speed == 0) // eğer düşmanın hızı sıfır ise düşman bekliyor
        {
            animator.SetBool("isIdling", true); // düşman bekleme animasyonunu aktifleştir
        }
        if(hasSeenPlayer == false) // eğer oyuncu görülmemiş ise sağa sola gider
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        if (hasSeenPlayer == true) // eğer oyuncu görülmüş ise oyuncuyu takip eder ve oyuncu konumuna göre oyuncuya yüzünü döner
        {
            if (playerTransform.position.x > transform.position.x && faceRight) //if the target is to the right of enemy and the enemy is not facing right
                Flip();
            if (playerTransform.position.x < transform.position.x && !faceRight)
                Flip();
            transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
        }

        if (health <= 0) // eğer canı sıfır veya sıfırın altında ise düşmanı yok et ve oyuncuya 100 puan ekle
        {
            Destroy(gameObject);
            //gameObject.GetComponent<PlayerStats>().GetScore(100);
            PlayerStats.GetComponent<PlayerStats>().GetScore(100);
        }

        

    }

    IEnumerator SwitchDirections() // belirtilen süre kadar bekle ve yön değiştirme metodunu çağır 
    {
        yield return new WaitForSeconds(turnDelay);
        Switch();
    }

    private void Switch() // yön değiştirme metodu
    {
        if(hasSeenPlayer == false) // eğer oyuncu görülmüş ise
        {
            animator.SetBool("isLeft", true);
            animator.SetBool("isRight", false);
            faceRight = !faceRight;
            animator.SetBool("isLeft", false);
            animator.SetBool("isRight", true);
            Vector3 scaler = transform.localScale;
            scaler.x *= -1;
            transform.localScale = scaler;
            speed *= -1;
            StartCoroutine(SwitchDirections());
        }
    }

    void Flip() // oyuncu görüldüğü taktirde oyuncuyu takip ederken oyuncunun bulunduğu konuma göre yüzünü dönmesi için çevirme metodu
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
        faceRight = !faceRight;
    }


    public void TakeDamage(int value) // düşmanın canının azalması
    {
        //rb.AddForce(Vector2.right * 100);
        health = health - value;

    }
    void OnCollisionStay2D(Collision2D collision) // eğer oyuncuya temas ediliyorsa
    {
        if (collision.gameObject.name == "Player"){
            
            PlayerStats.GetComponent<PlayerStats>().GetDamage(1);
            animatorPlayer.SetBool("IsHurt", true);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision) // oyuncuya temas edilmişse görüldü olarak kabul et ve oyuncunun canını azalt, oyuncu yaralanma animasyonu oynat
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player") // eğer oyuncuysa
        {
            flagfalan = true;
            hasSeenPlayer = true;
        }
        if (collision.gameObject.tag == "Bullet") // eğer mermiyse
        {
            TakeDamage(25); // düşmana hasar
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            flagfalan = false; // temas ortadan kalmış ise boolean değerini değiştir
            
        }
    }

    private void OnCollisionExit2D(Collision2D collision) // oyuncuyla temastan çıkılmışsa oyuncunun yaralanma animasyonunu bitir
    {
        animatorPlayer.SetBool("IsHurt", false);
    }
}
