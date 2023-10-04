using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_animi : MonoBehaviour
{
    // Start is called before the first frame update

    Material material;
    Vector2 movement;
    public Vector2 speed;

    void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        movement += speed * Time.deltaTime;
        movement.y -= Time.timeSinceLevelLoad * Time.deltaTime * 0.01f;
        material.mainTextureOffset = movement;
    }
}
