using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_control : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;

    public float speed;     //角色速度
    float Xvelocity;

    public float checkRadius;           //檢查落點半徑
    public LayerMask platform;          //檢測圖層
    public GameObject groundcheck;      //在角色腳下生成GameObject來檢測地面
    public bool isOnGround;             //是否在平台上

    bool playerdead;                    //角色是否死亡

    public FixedJoystick joystick;      //虛擬搖桿

    public AudioSource banana_sound;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isOnGround = Physics2D.OverlapCircle(groundcheck.transform.position, checkRadius, platform);

        anim.SetBool("isonground", isOnGround);

        Movement();
    }

    void Movement()
    {
        //Xvelocity = joystick.input.x;
        Xvelocity = Input.GetAxisRaw("Horizontal");       //左右按鍵
        //Yvelocity = Input.GetAxisRaw("Vertical");         上下按鍵

        rb.velocity = new Vector2(Xvelocity * speed, rb.velocity.y); 

        anim.SetFloat("speed",Mathf.Abs(rb.velocity.x));    //跑動動畫
        if (Xvelocity != 0)
        {
            transform.localScale = new Vector3(Xvelocity, 1, 1);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("fan"))
        {
            rb.velocity = new Vector2(rb.velocity.x, 10f);  //彈跳效果
        }
        if (other.gameObject.CompareTag("banana"))
        {
            banana_sound.Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Spikes"))
        {
            anim.SetTrigger("hit");
        }
    }

    public void Playerdead()
    {
        playerdead = true;
        GameManager.GameOver(playerdead);
    }

    private void OnDrawGizmosSelected()             //畫腳下圖示的圈圈
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(groundcheck.transform.position, checkRadius);
    }


}
