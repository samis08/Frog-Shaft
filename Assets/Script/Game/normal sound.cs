using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class normalsound : MonoBehaviour
{
    private AudioSource normalaudio;
    // Start is called before the first frame update
    void Start()
    {
        normalaudio = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            normalaudio.Play();
        }
    }
}
