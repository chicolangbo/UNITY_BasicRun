using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb2d;
    private AudioSource audioSource;
    public AudioClip dieAudioClip;

    public float jumpForce = 400f;
    private int jumpCount = 0;

    private bool isDead = false;
    private bool isGrounded = false;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && jumpCount<2) // ��Ŭ��
        {
            ++jumpCount;
            rb2d.velocity = Vector3.zero; // �ڵ� �߰� �� �� ���� ��
            rb2d.AddForce(Vector2.up * jumpForce);
            audioSource.Play();
        }

        if(Input.GetMouseButtonUp(0) && rb2d.velocity.y > 0)
        {
            rb2d.velocity *= 0.5f;
        }

        anim.SetBool("Grounded", isGrounded);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Ground"))
        {
            if (collision.contacts[0].normal.y > 0.7f) // contacts�� �浹�� ������ ��� ����ü(������, �븻�� �ٵ� ����)
                // ��ä�� ������� �˻�
            {
                isGrounded = true;
                jumpCount = 0;
            }

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dead") && !isDead)
        {
            Die();
        }
    }

    public void Die()
    {
        isDead = true;
        anim.SetTrigger("Die");
        rb2d.velocity = Vector3.zero;
        audioSource.clip = dieAudioClip; // ����� Ŭ�� �ٲٱ�
        audioSource.Play();

        GameManager.Instance.OnPlayerDead();
    }

}
