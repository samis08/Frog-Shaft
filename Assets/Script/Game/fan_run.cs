using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fan_run : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;
    public bool isonFan;
    private AudioSource fan_audio;
    void Start()
    {
        animator = GetComponent<Animator>();
        fan_audio = GetComponent<AudioSource>();
    }

    //¸I¼²ª«ÅéªºTag
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            fan_audio.Play();
            animator.Play("Fan_run");
            isonFan = true;
        }
        isonFan = false;
        //isonFan = false;
        animator.SetBool("play_on", isonFan);
    }

}
