using System.Collections;
using System.Collections.Generic;
using System.IO;                //file相關
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;
using Unity.VisualScripting;
using UnityEditor;
using System;

public class GameManager : MonoBehaviour
{
    static GameManager instance;

    public Text timeScore;
    public Text Highscore;
    public GameObject gameoverUI;
    public GameObject Menu;
    //public GameObject joystick;

    public float time_now = 0;
    bool Eat;

    public AudioSource tick;

    private void Start()
    {
        Time.timeScale = 0f;
        GameData.highscore = int.Parse(File.ReadAllText("Assets/Script/bestscore.txt"));    //讀高分文件
    }
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        instance = this;
    }

    void Update()
    {
        timeScore.text = Time.timeSinceLevelLoad.ToString("000");
        if(Mathf.Round(Time.timeSinceLevelLoad) > time_now + 8)
        {
            tick.Play();
            Time.timeScale = 1f;
            time_now = Mathf.Round(Time.timeSinceLevelLoad);
        }
    }

    public void Startgame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        instance.Menu.SetActive(false);
        //instance.joystick.SetActive(true);
        Time.timeScale = 1f;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);     //回到初始狀態的畫面
        Time.timeScale = 1f;
    }
    public void Quit() 
    { 
        Application.Quit();
    }

    public static void GameOver(bool dead)
    {
        if(dead)
        {
            if (GameData.highscore <= Mathf.Round(Time.timeSinceLevelLoad))
            {
                GameData.highscore = Mathf.Round(Time.timeSinceLevelLoad);
                File.WriteAllText("Assets/Script/bestscore.txt", GameData.highscore.ToString());    //覆蓋高分文件
            }

            GameData.highscore = int.Parse(File.ReadAllText("Assets/Script/bestscore.txt"));        //讀取分數

            instance.Highscore.text = GameData.highscore.ToString("0");
            instance.gameoverUI.SetActive(true);
            //instance.joystick.SetActive(false);
            Time.timeScale = 0f;
        }
    }
    public static void iseat(bool banana_eat)
    {
        if (banana_eat)
        {
            instance.time_now = Time.timeSinceLevelLoad;
            banana_eat = false;
        }
    }

    static class GameData
    {
        public static float highscore;
    }

}
