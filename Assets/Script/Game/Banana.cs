using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Banana : MonoBehaviour
{
    public bool banana_eat;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Time.timeScale = 0.4f;
            banana_eat = true;
        }
    }

}
