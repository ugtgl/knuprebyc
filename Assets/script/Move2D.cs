using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2D : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float horizontalMove = 2f;
    public GameObject player;
    private bool isJumping;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Platform") && isJumping == false)
        {
            player.transform.parent = other.gameObject.transform;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            player.transform.parent = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;
    }
    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 2f), ForceMode2D.Impulse);
            isJumping = true;
            animator.SetBool("isJumping", true);
        }
    }
}
