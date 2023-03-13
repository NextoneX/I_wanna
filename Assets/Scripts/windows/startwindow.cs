using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///脚本：startwindow.cs
///时间：2022/9/2 16:03
///功能：开始游戏界面
///</summary>
public class startwindow : windowRoot
{
    public recordwindow recordwindow;

    protected override void Initwindow()
    {
        base.Initwindow();
    }

    private void Update()
    {
        Enterrecordwindow();
    }

    private void Enterrecordwindow()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            SetWindowState(false);
            recordwindow.SetWindowState(true);
        }
    }
}
