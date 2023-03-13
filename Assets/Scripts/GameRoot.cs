using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///脚本：GameRoot.cs
///时间：2022/9/2 16:00
///功能：游戏主入口
///</summary>
public class GameRoot : MonoBehaviour
{
    public static GameRoot Instance;

    public startwindow startwindow;

    private void Start()
    {
        Instance = this;
        Clearwindow();
        InitGame();
    }

    private void Clearwindow()
    {
        Transform canvas = transform.Find("Canvas");
        for(int i = 0; i < canvas.childCount; i++)
        {
            canvas.GetChild(i).gameObject.SetActive(false);
        }
        startwindow.SetWindowState(true);
    }

    private void InitGame()
    {
        ResourceSvc resourceSvc = GetComponent<ResourceSvc>();
        resourceSvc.InitSvc();
        
    }
}
