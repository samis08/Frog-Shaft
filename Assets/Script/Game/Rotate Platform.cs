using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlatform : MonoBehaviour
{
    private AudioSource rotate_audio;
    // Start is called before the first frame update
    void Start()
    {
        rotate_audio = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            rotate_audio.Play();
        }
    }
}
