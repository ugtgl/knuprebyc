using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering.PostProcessing;

public class PlayerStats : MonoBehaviour
{
    public TextMeshProUGUI textScore;
    public TextMeshProUGUI textHealth;
    public TextMeshProUGUI textMana;
    public TextMeshProUGUI gameOver;
    public GameObject damageScreen;
    public GameObject player;
    public GameObject button;
    public GameObject returnMainMenu;
    public int totalScore;
    int oldScore;
    //int health;
    //int mana;
    float health;
    float oldHealth;
    float healthIncreaseValue;
    float currentHealth;
    float mana;
    float oldMana;
    float manaIncreaseValue;
    float currentMana;
    public bool isTired;
    public Animator animator;
    public Animator animator2;
    public Animator animator3;
    // Start is called before the first frame update
    void Start()
    {
        health = 100; //can
        mana = 100; //mana
        currentMana = 100; //anlıkmana
        currentHealth = 100; //anlıkcan
        manaIncreaseValue = 3f; //manaartışmiktarı
        healthIncreaseValue = 2f; //canartışmiktarı
        button.SetActive(false);
        returnMainMenu.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // sol klik ise mana düşür
        {
            DecreaseMana(10);
        }

        if (currentHealth == 0) //can 0 ise öldü
        {
            player.SetActive(false);
            button.SetActive(true);
            returnMainMenu.SetActive(true);

            //animator3.SetBool("IsDead", true);
            gameOver.text = "You are dead.";

            healthIncreaseValue = 0; //iyileşmeyi durdur
        }

        currentMana += manaIncreaseValue * Time.deltaTime; //mana artır
        currentHealth += healthIncreaseValue * Time.deltaTime; //can artır

        if (currentMana > mana) // anlık mana 100ü geçerse 100e sabitle
        {
            currentMana = 100;
        }
        if(currentMana < 0) // anlık mana sıfırın altına düşerse 0 a sabitle
        {
            currentMana = 0;
        }
        if (currentMana <= 10) // anlık mana sıfırın altına inerse karakter yoruldu
        {
            isTired = true;
            animator2.SetBool("manaEmpty", true);
        }
        if(currentMana > 10) // mana sıfırdan yüksekse yorulmamıştır
        {
            isTired = false;
            animator2.SetBool("manaEmpty", false);
        }

        if(currentHealth > health) // anlık can 100ü geçerse 100e sabitle
        {
            currentHealth = 100;
        }
        if (currentHealth < 25) // anlık can 25in altında kalırsa ekran kırmızı olarak yanıp söner
        {
            damageScreen.gameObject.SetActive(true);
            animator.SetBool("healthIsLow", true);
        }
        if(currentHealth > 25) // anlık can 25in üstünde ise ekran kırmızı olarak yanıp sönmez
        {
            damageScreen.gameObject.SetActive(false);
            animator.SetBool("healthIsLow", false);
        }

        if(currentHealth < 0) // anlık can sıfırın altına düşerse sıfıra sabitle
        {
            currentHealth = 0;
        }

        if (totalScore != oldScore)
        {
            textScore.text = "Score: " + totalScore.ToString();
            oldScore = totalScore;
        }
        if (currentHealth != oldHealth)
        {
            textHealth.text = ((int)currentHealth).ToString();
            oldHealth = currentHealth;
        }
        if (currentMana != oldMana)
        {
            textMana.text = ((int)currentMana).ToString();
            oldMana = currentMana;
        }

        //textScore.text = "Score:" + totalScore.ToString(); // UI'ye güncel skoru yaz
        //textHealth.text = health.ToString();
        //textMana.text = ((int)currentMana).ToString(); // UI'ye güncel manayı yaz
        //textHealth.text = ((int)currentHealth).ToString(); // UI'ye güncel canı yaz

    }

    public void GetScore(int score)
    {
        totalScore += score; // toplam skora belirtilen skoru ekle
    }
    public void GetDamage(float damage)
    {
        currentHealth -= damage; // anlık candan belirtilen miktar kadar düşür
    }
    public void DecreaseMana(float decreasedmana)
    {
        currentMana -= decreasedmana; // anlık manadan belirtilen miktar kadar düşür
    }
}
