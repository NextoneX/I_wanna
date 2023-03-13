using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///脚本：GameWindow.cs
///时间：2022/9/3 15:00
///功能：
///</summary>
public class GameWindow : windowRoot
{
    public GameObject player;
    public GameObject gameOverTip;
    public GameObject[] levelArr;
    public Transform startPoint;
    private int levelCount;

    protected override void Initwindow()
    {
        base.Initwindow();
        levelCount = 0;
        GameStart();
        LoadLevel();
    }

    private void GameStart()
    {
        player.SetActive(true);
        gameOverTip.SetActive(false);
    }

    private void LoadLevel()
    {
        GameObject level = Instantiate(levelArr[levelCount]);
        level.name = "Level" + levelCount;
        level.transform.SetParent(transform, false);
        player.transform.localPosition = level.transform.Find("StartPoint").localPosition;
    }

    private void DeleteLevel()
    {
        Destroy(transform.Find("Level" + levelCount).gameObject);
    }

    public void NextLevel()
    {
        DeleteLevel();
        levelCount++;
        LoadLevel();
    }

    public void GameOver()
    {
        player.SetActive(false);
        gameOverTip.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Restart();
        }
    }

    private void Restart()
    {
        GameStart();
        DeleteLevel();
        LoadLevel();
    }
}
