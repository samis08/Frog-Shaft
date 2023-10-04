using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_up : MonoBehaviour
{
    // Start is called before the first frame update

    private Vector3 movement;
    public float speed;

    GameObject topline;

    void Start()
    {
        topline = GameObject.Find("Topline");       //查找某個物件
        movement.y = speed + Time.timeSinceLevelLoad * 0.05f;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlatform();
    }

    void MovePlatform()
    {
        transform.position += movement * Time.deltaTime;

        if(transform.position.y >= topline.transform.position.y)
        {
            Destroy(gameObject);
        }
    }
}
