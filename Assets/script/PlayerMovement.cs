using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public Animator animator2;
    public GameObject bullet;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    public float runSpeed = 40f;
    bool PlaySound;
    public AudioSource audioSource;
    public menuToggle menuToggle;
    // Start is called before the first frame update
    void Start()
    {
        bullet.SetActive(false);
        PlaySound = true;
        menuToggle = menuToggle.GetComponent<menuToggle>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
            animator2.SetBool("IsCrouching", true);
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
            animator2.SetBool("IsCrouching", false);
        }

        if (Input.GetKey(KeyCode.LeftShift)) {

            if (runSpeed != 0)
            {
                animator.SetBool("IsWalking", true);
            }
            runSpeed = 3f;
        }
        else if (Input.GetKey(KeyCode.LeftShift) == false)
        {
            animator.SetBool("IsWalking", false);
            runSpeed = 7f;
        }

        if (Input.GetKey(KeyCode.Mouse0) && crouch == false)
        {
            bullet.SetActive(true);
            animator.SetBool("IsShooting", true);
            animator2.SetBool("IsShooting", true);
            if(PlaySound == true && menuToggle.menuOpened == false )
            {
                audioSource.loop = true;
                audioSource.Play();
                PlaySound = false;
            }

            if(runSpeed > 0)
            {
                animator.SetBool("IsRunShooting", true);
                if (PlaySound == true && menuToggle.menuOpened == false)
                {
                    audioSource.loop = true;
                    audioSource.Play();
                PlaySound = false;
                }
            }
        }
        else if (Input.GetKey(KeyCode.Mouse0) ==false)
        {
            bullet.SetActive(false);
            animator.SetBool("IsShooting", false);
            animator2.SetBool("IsShooting", false);
            if (runSpeed > 0)
            {
                animator.SetBool("IsRunShooting", false);
            }
        }
        if (Input.GetKey(KeyCode.Mouse0) && crouch == true)
        {
            bullet.SetActive(true);
            animator2.SetBool("IsCrouchShooting", true);
            animator2.SetBool("IsShooting", false);
            if (PlaySound == true && menuToggle.menuOpened == false)
            {
                audioSource.loop = true;
                audioSource.Play();
                PlaySound = false;
            }
        }
        else if(Input.GetKey(KeyCode.Mouse0) == false)
        {
            bullet.SetActive(false);
            animator2.SetBool("IsCrouchShooting", false);
        }
        audioSource.loop = false;
        if(audioSource.isPlaying == false)
        {
            PlaySound = true;
        }
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }
    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("need"))
        {
            //Destroy(other.gameObject);
            other.gameObject.SetActive(false);
        }
    }




    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
