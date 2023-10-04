using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_control : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;

    public float speed;     //����t��
    float Xvelocity;

    public float checkRadius;           //�ˬd���I�b�|
    public LayerMask platform;          //�˴��ϼh
    public GameObject groundcheck;      //�b����}�U�ͦ�GameObject���˴��a��
    public bool isOnGround;             //�O�_�b���x�W

    bool playerdead;                    //����O�_���`

    public FixedJoystick joystick;      //�����n��

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
        Xvelocity = Input.GetAxisRaw("Horizontal");       //���k����
        //Yvelocity = Input.GetAxisRaw("Vertical");         �W�U����

        rb.velocity = new Vector2(Xvelocity * speed, rb.velocity.y); 

        anim.SetFloat("speed",Mathf.Abs(rb.velocity.x));    //�]�ʰʵe
        if (Xvelocity != 0)
        {
            transform.localScale = new Vector3(Xvelocity, 1, 1);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("fan"))
        {
            rb.velocity = new Vector2(rb.velocity.x, 10f);  //�u���ĪG
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

    private void OnDrawGizmosSelected()             //�e�}�U�ϥܪ����
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(groundcheck.transform.position, checkRadius);
    }


}
