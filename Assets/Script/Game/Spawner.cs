using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sponder : MonoBehaviour
{

    public List<GameObject> platforms = new List<GameObject>();

    public float spawnTime;
    private float countTime;
    private float totalTime;    //計算40s用
    public float spawnUp = 1;      //每40s +1

    private Vector3 spawnPosition;

    // Update is called once per frame
    void Update()
    {
        SpawnPlatform();
    }

    public void SpawnPlatform()
    {
        countTime += Time.deltaTime;
        totalTime += Time.deltaTime;
        spawnPosition = transform.position;
        spawnPosition.x = Random.Range(-3.3f, 3.3f);    //x軸生成於-3.3~3.3
        
        if(totalTime >= 40)
        {
            spawnUp += 1;
            totalTime = 0;
        }

        if (countTime >= spawnTime / spawnUp)
        {
            Createplatform();
            countTime = 0;
        }

    }

    public void Createplatform()
    {
        int index = Random.Range(0, platforms.Count);
        
        int SpikeNum = 0;
        
        if (index == platforms.Count)
        {
            SpikeNum++;
        }

        if (SpikeNum > 1)
        {        
            index = Random.Range(0, platforms.Count-1);
            SpikeNum = 0;
        }

        GameObject newPlatform = Instantiate(platforms[index], spawnPosition, Quaternion.identity);
        newPlatform.transform.SetParent(this.gameObject.transform);

    }

}
